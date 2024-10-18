using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Internal.DocItemGenerators;
using DefaultDocumentation.Models;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal;

internal sealed class GeneralContext : Context, IGeneralContext, IDocItemsContext
{
    private readonly Dictionary<Type, Context> _contexts;
    private readonly ConcurrentDictionary<DocItem, string> _fileNames;
    private readonly Dictionary<string, DocItem> _items;
    private readonly HashSet<DocItem> _itemsWithOwnPage;

    public IEnumerable<IFileNameFactory> AllFileNameFactory => _contexts
        .Values
        .Concat(Enumerable.Repeat(this, 1))
        .Where(context => context.FileNameFactory != null)
        .Select(context => context.FileNameFactory!)
        .Distinct();

    public GeneralContext(
        JObject config,
        Type[] availableTypes,
        Settings settings)
        : base(config, availableTypes)
    {
        FileNameFactory.ThrowIfNull();

        Settings = settings;
        _items = [];
        _itemsWithOwnPage = [];

        _contexts = availableTypes
            .Where(type => typeof(DocItem).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (Type: type, Setting: GetSetting<JObject>(type.Name)))
            .Where(tuple => tuple.Setting != null)
            .ToDictionary(tuple => tuple.Type, tuple => new Context(tuple.Setting!, availableTypes));
        _fileNames = new ConcurrentDictionary<DocItem, string>();

        Elements = GetAllAvailableImplementations<IElement>(availableTypes, element => element.Name)
            .Values
            .Concat(GetImplementations<IElement>(availableTypes, element => element.Name, GetSetting<string[]>(nameof(IRawSettings.Elements))) ?? [])
            .GroupBy(element => element.Name)
            .Select(group => group.Last())
            .ToDictionary(element => element.Name);
        UrlFactories = GetImplementations<IUrlFactory>(availableTypes, urlFactory => urlFactory.Name, GetSetting<string[]>(nameof(IRawSettings.UrlFactories))) ?? [];

        Settings.Logger.Info($"Elements that will be used:{string.Concat(Elements.Select(element => $"{Environment.NewLine}  - {element.Key}: {element.Value.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"UrlFactories that will be used:{string.Concat(UrlFactories.Select(urlFactory => $"{Environment.NewLine}  - {urlFactory.GetType().AssemblyQualifiedName}"))}");
        Settings.Logger.Info($"FileNameFactory that will be used: {FileNameFactory!.GetType().AssemblyQualifiedName}");
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

        IDocItemGenerator[] docItemGenerators =
        [
            new DocItemReader(),
            new ExternDocItemReader(),
            new OwnPageSetter(),
            .. GetImplementations<IDocItemGenerator>(availableTypes, docItemGenerator => docItemGenerator.Name, GetSetting<string[]>(nameof(IRawSettings.DocItemGenerators))) ?? []
        ];

        foreach (IDocItemGenerator docItemGenerator in docItemGenerators)
        {
            Settings.Logger.Info($"using DocItemGenerator:{docItemGenerator.GetType().AssemblyQualifiedName}");
            docItemGenerator.Generate(this);
        }
    }

    #region IGeneralContext

    public ISettings Settings { get; }

    public IReadOnlyDictionary<string, DocItem> Items => _items;

    public IReadOnlyCollection<DocItem> ItemsWithOwnPage => _itemsWithOwnPage;

    public IReadOnlyDictionary<string, IElement> Elements { get; }

    public IEnumerable<IUrlFactory> UrlFactories { get; }

    public IContext GetContext(Type? type) => type != null && _contexts.TryGetValue(type, out Context context) ? context : this;

    public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, newItem => (this.GetContext(newItem).FileNameFactory ?? FileNameFactory!).GetFileName(this, newItem));

    #endregion

    #region IDocItemsContext

    IDictionary<string, DocItem> IDocItemsContext.Items => _items;

    ICollection<DocItem> IDocItemsContext.ItemsWithOwnPage => _itemsWithOwnPage;

    T? IDocItemsContext.GetSetting<T>(Type? type, string name) where T : default => GetContext(type).GetSetting<T>(name);

    #endregion
}
