using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal
{
    internal sealed class GeneralContext : Context, IGeneralContext
    {
        private readonly Dictionary<Type, Context> _contexts;
        private readonly PathCleaner _pathCleaner;
        private readonly ConcurrentDictionary<DocItem, string> _fileNames;
        private readonly ConcurrentDictionary<string, string> _urls;
        private readonly IUrlFactory[] _urlFactories;

        public IEnumerable<IFileNameFactory> AllFileNameFactory => _contexts
            .Values
            .Concat(Enumerable.Repeat(this, 1))
            .Select(c => c.FileNameFactory)
            .Where(f => f != null)
            .Distinct();

        public GeneralContext(
            JObject config,
            Type[] availableTypes,
            Settings settings,
            IReadOnlyDictionary<string, DocItem> items)
            : base(config, availableTypes)
        {
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
                .ToDictionary(t => t.t, t => new Context(t.Item2, availableTypes));
            _pathCleaner = new PathCleaner(settings.InvalidCharReplacement);
            _fileNames = new ConcurrentDictionary<DocItem, string>();
            _urls = new ConcurrentDictionary<string, string>();

            string[] urlFactories = GetSetting<string[]>(nameof(IRawSettings.UrlFactories));
            Dictionary<string, IUrlFactory> availableUrlFactories = availableTypes
                .Where(t => typeof(IUrlFactory).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (IUrlFactory)Activator.CreateInstance(t))
                .GroupBy(w => w.Name)
                .ToDictionary(w => w.Key, w => w.Last());
            _urlFactories = urlFactories
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
            Settings.Logger.Info($"FileNameFactory that will be used: {FileNameFactory?.GetType().AssemblyQualifiedName}");
            Settings.Logger.Info($"UrlFactories that will be used:{string.Concat(_urlFactories?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? Enumerable.Empty<string>())}");
            Settings.Logger.Info($"Sections that will be used:{string.Concat(Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? Enumerable.Empty<string>())}");

            foreach (KeyValuePair<Type, Context> pair in _contexts)
            {
                Settings.Logger.Info($"FileNameFactory that will be used for {pair.Key.Name}: {pair.Value.FileNameFactory?.GetType().AssemblyQualifiedName}");
                Settings.Logger.Info($"SectionWriter that will be used for {pair.Key.Name}:{string.Concat(pair.Value.Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? Enumerable.Empty<string>())}");
            }
        }

        #region IGeneralContext

        public ISettings Settings { get; }

        public IReadOnlyDictionary<string, DocItem> Items { get; }

        public IReadOnlyDictionary<string, IElement> Elements { get; }

        public IContext GetContext(Type type) => _contexts.TryGetValue(type, out Context context) ? context : this;

        public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, i => _pathCleaner.Clean((this.GetContext(item)?.FileNameFactory ?? FileNameFactory).GetFileName(this, i)));

        public string GetUrl(string id) => _urls.GetOrAdd(id, i => _pathCleaner.Clean(_urlFactories.Select(f => f.GetUrl(this, i)).FirstOrDefault(url => url is not null)));

        #endregion
    }
}
