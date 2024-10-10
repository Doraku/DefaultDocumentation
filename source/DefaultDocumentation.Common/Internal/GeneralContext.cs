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
        .Where(c => c.FileNameFactory != null)
        .Select(c => c.FileNameFactory!)
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
            .Where(t => typeof(IElement).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t => (IElement)Activator.CreateInstance(t))
            .GroupBy(w => w.Name)
            .ToDictionary(w => w.Key, w => w.Last());

        foreach (string id in GetSetting<string[]>(nameof(IRawSettings.Elements)) ?? Enumerable.Empty<string>())
        {
            IElement writer = availableTypes
                .Where(t => typeof(IElement).IsAssignableFrom(t) && !t.IsAbstract && $"{t.FullName} {t.Assembly.GetName().Name}" == id)
                .Select(t => (IElement)Activator.CreateInstance(t))
                .FirstOrDefault()
                ?? throw new Exception($"Element '{id}' not found");

            availableElements[writer.Name] = writer;
        }

        Settings = settings;
        Items = items;
        Elements = availableElements;

        _contexts = typeof(DocItem).Assembly
            .GetTypes()
            .Where(t => typeof(DocItem).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t => (t, GetSetting<JObject>(t.Name)))
            .Where(t => t.Item2 != null)
            .ToDictionary(t => t.t, t => new Context(t.Item2!, availableTypes));
        _fileNames = new ConcurrentDictionary<DocItem, string>();

        string[] urlFactories = GetSetting<string[]>(nameof(IRawSettings.UrlFactories)) ?? [];
        Dictionary<string, IUrlFactory> availableUrlFactories = availableTypes
            .Where(t => typeof(IUrlFactory).IsAssignableFrom(t) && !t.IsAbstract)
            .Select(t => (IUrlFactory)Activator.CreateInstance(t))
            .GroupBy(w => w.Name)
            .ToDictionary(w => w.Key, w => w.Last());
        UrlFactories = urlFactories
            .Select(id =>
                availableUrlFactories.TryGetValue(id, out IUrlFactory urlFactory)
                ? urlFactory
                : availableTypes
                    .Where(t => typeof(IUrlFactory).IsAssignableFrom(t) && !t.IsAbstract && $"{t.FullName} {t.Assembly.GetName().Name}" == id)
                    .Select(t => (IUrlFactory)Activator.CreateInstance(t))
                    .FirstOrDefault()
                ?? throw new Exception($"UrlFactory '{id}' not found"))
            .ToArray();

        Settings.Logger.Info($"Elements that will be used:{string.Concat(Elements.Select(e => $"{Environment.NewLine}  {e.Key}: {e.Value.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"FileNameFactory that will be used: {FileNameFactory!.GetType().AssemblyQualifiedName}");
        Settings.Logger.Info($"UrlFactories that will be used:{string.Concat(UrlFactories.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"Sections that will be used:{string.Concat(Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? [])}");

        foreach (KeyValuePair<Type, Context> pair in _contexts)
        {
            Settings.Logger.Info($"FileNameFactory that will be used for {pair.Key.Name}: {pair.Value.FileNameFactory?.GetType().AssemblyQualifiedName}");
            Settings.Logger.Info($"SectionWriter that will be used for {pair.Key.Name}:{string.Concat(pair.Value.Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? [])}");
        }
    }

    #region IGeneralContext

    public ISettings Settings { get; }

    public IReadOnlyDictionary<string, DocItem> Items { get; }

    public IReadOnlyDictionary<string, IElement> Elements { get; }

    public IEnumerable<IUrlFactory> UrlFactories { get; }

    public IContext GetContext(Type? type) => type != null && _contexts.TryGetValue(type, out Context context) ? context : this;

    public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, i => (this.GetContext(item).FileNameFactory ?? FileNameFactory!).GetFileName(this, i));

    #endregion
}
