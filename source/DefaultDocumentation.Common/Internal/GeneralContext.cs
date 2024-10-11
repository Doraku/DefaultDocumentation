using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal;

internal sealed class GeneralContext : Context, IGeneralContext
{
    private readonly Dictionary<Type, Context> _contexts;
    private readonly ConcurrentDictionary<DocItem, string> _fileNames;

    public IEnumerable<IFileNameFactory> AllFileNameFactory => _contexts
        .Values
        .Concat(Enumerable.Repeat(this, 1))
        .Where(context => context.FileNameFactory != null)
        .Select(context => context.FileNameFactory!)
        .Distinct();

    public GeneralContext(
        JObject config,
        Type[] availableTypes,
        Settings settings,
        IReadOnlyDictionary<string, DocItem> items)
        : base(config, availableTypes)
    {
        FileNameFactory.ThrowIfNull();

        Dictionary<string, IElement> availableElements = availableTypes
            .Where(type => typeof(IElement).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (IElement)Activator.CreateInstance(type))
            .GroupBy(element => element.Name, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.Last(), StringComparer.OrdinalIgnoreCase);

        foreach (string id in GetSetting<string[]>(nameof(IRawSettings.Elements)) ?? Enumerable.Empty<string>())
        {
            IElement writer = availableTypes
                .Where(type => typeof(IElement).IsAssignableFrom(type) && !type.IsAbstract && $"{type.FullName} {type.Assembly.GetName().Name}" == id)
                .Select(type => (IElement)Activator.CreateInstance(type))
                .FirstOrDefault()
                ?? throw new Exception($"Element '{id}' not found");

            availableElements[writer.Name] = writer;
        }

        Settings = settings;
        Items = items;
        Elements = availableElements;

        _contexts = typeof(DocItem).Assembly
            .GetTypes()
            .Where(type => typeof(DocItem).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (type, GetSetting<JObject>(type.Name)))
            .Where(tuple => tuple.Item2 != null)
            .ToDictionary(tuple => tuple.type, tuple => new Context(tuple.Item2!, availableTypes));
        _fileNames = new ConcurrentDictionary<DocItem, string>();

        string[] urlFactories = GetSetting<string[]>(nameof(IRawSettings.UrlFactories)) ?? [];
        Dictionary<string, IUrlFactory> availableUrlFactories = availableTypes
            .Where(type => typeof(IUrlFactory).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (IUrlFactory)Activator.CreateInstance(type))
            .GroupBy(urlFactory => urlFactory.Name)
            .ToDictionary(urlFactory => urlFactory.Key, urlFactory => urlFactory.Last(), StringComparer.OrdinalIgnoreCase);
        UrlFactories = urlFactories
            .Select(id =>
                availableUrlFactories.TryGetValue(id, out IUrlFactory urlFactory)
                ? urlFactory
                : availableTypes
                    .Where(type => typeof(IUrlFactory).IsAssignableFrom(type) && !type.IsAbstract && $"{type.FullName} {type.Assembly.GetName().Name}" == id)
                    .Select(type => (IUrlFactory)Activator.CreateInstance(type))
                    .FirstOrDefault()
                ?? throw new Exception($"UrlFactory '{id}' not found"))
            .ToArray();

        Settings.Logger.Info($"Elements that will be used:{string.Concat(Elements.Select(element => $"{Environment.NewLine}  - {element.Key}: {element.Value.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"FileNameFactory that will be used: {FileNameFactory!.GetType().AssemblyQualifiedName}");
        Settings.Logger.Info($"UrlFactories that will be used:{string.Concat(UrlFactories.Select(urlFactory => $"{Environment.NewLine}  - {urlFactory.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"Sections that will be used:{string.Concat(Sections?.Select(section => $"{Environment.NewLine}  - {section.GetType().AssemblyQualifiedName}") ?? [])}");

        foreach ((Type docItemType, Context context) in _contexts)
        {
            if (context.FileNameFactory != null)
            {
                Settings.Logger.Info($"FileNameFactory that will be used for {docItemType.Name}: {context.FileNameFactory?.GetType().AssemblyQualifiedName}");
            }

            if (context.Sections?.Any() ?? false)
            {
                Settings.Logger.Info($"Sections that will be used for {docItemType.Name}:{string.Concat(context.Sections.Select(section => $"{Environment.NewLine}  - {section.GetType().AssemblyQualifiedName}"))}");
            }
        }
    }

    #region IGeneralContext

    public ISettings Settings { get; }

    public IReadOnlyDictionary<string, DocItem> Items { get; }

    public IReadOnlyDictionary<string, IElement> Elements { get; }

    public IEnumerable<IUrlFactory> UrlFactories { get; }

    public IContext GetContext(Type? type) => type != null && _contexts.TryGetValue(type, out Context context) ? context : this;

    public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, newItem => (this.GetContext(newItem).FileNameFactory ?? FileNameFactory!).GetFileName(this, newItem));

    #endregion
}
