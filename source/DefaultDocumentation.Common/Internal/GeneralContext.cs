using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal
{
    internal sealed class GeneralContext : Context, IGeneralContext
    {
        private readonly Dictionary<Type, Context> _contexts;
        private readonly PathCleaner _pathCleaner;
        private readonly ConcurrentDictionary<DocItem, string> _fileNames;
        private readonly ConcurrentDictionary<string, string> _urls;
        private readonly Func<DocItem, string> _urlFactory;

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
            Dictionary<string, IElementWriter> elementWriters = availableTypes
                .Where(t => typeof(IElementWriter).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (IElementWriter)Activator.CreateInstance(t))
                .GroupBy(w => w.Name)
                .ToDictionary(w => w.Key, w => w.Last());

            foreach (string element in GetSetting<string[]>(nameof(Elements)) ?? Enumerable.Empty<string>())
            {
                IElementWriter writer = availableTypes
                    .Where(t => typeof(IElementWriter).IsAssignableFrom(t) && !t.IsAbstract && $"{t.FullName} {t.Assembly.GetName().Name}" == element)
                    .Select(t => (IElementWriter)Activator.CreateInstance(t))
                    .FirstOrDefault()
                    ?? throw new Exception($"ElementWriter '{element}' not found");

                elementWriters[writer.Name] = writer;
            }

            Settings = settings;
            Items = items;
            Elements = elementWriters;

            _contexts = typeof(DocItem).Assembly
                .GetTypes()
                .Where(t => typeof(DocItem).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (t, GetSetting<JObject>(t.Name)))
                .Where(t => t.Item2 != null)
                .ToDictionary(t => t.t, t => new Context(t.Item2, availableTypes));
            _pathCleaner = new PathCleaner(settings.InvalidCharReplacement);
            _fileNames = new ConcurrentDictionary<DocItem, string>();
            _urls = new ConcurrentDictionary<string, string>();
            _urlFactory = item =>
            {
                if (item is ExternDocItem externItem)
                {
                    return externItem.Url;
                }

                DocItem pagedItem = item;
                while (!HasOwnPage(pagedItem))
                {
                    pagedItem = pagedItem.Parent;
                }

                string url = GetFileName(pagedItem);
                if (settings.RemoveFileExtensionFromLinks)
                {
                    url = Path.GetFileNameWithoutExtension(url);
                }
                if (item != pagedItem)
                {
                    url += "#" + _pathCleaner.Clean(item.FullName);
                }

                return url;
            };

            Settings.Logger.Info($"ElementWriter that will be used:{string.Concat(Elements.Select(e => $"{Environment.NewLine}  {e.Key}: {e.Value.GetType().AssemblyQualifiedName}"))}");
            Settings.Logger.Info($"FileNameFactory that will be used: {FileNameFactory?.GetType().AssemblyQualifiedName}");
            Settings.Logger.Info($"SectionWriter that will be used:{string.Concat(Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? Enumerable.Empty<string>())}");

            foreach (KeyValuePair<Type, Context> pair in _contexts)
            {
                Settings.Logger.Info($"FileNameFactory that will be used for {pair.Key.Name}: {pair.Value.FileNameFactory?.GetType().AssemblyQualifiedName}");
                Settings.Logger.Info($"SectionWriter that will be used for {pair.Key.Name}:{string.Concat(pair.Value.Sections?.Select(s => $"{Environment.NewLine}  {s.GetType().AssemblyQualifiedName}") ?? Enumerable.Empty<string>())}");
            }
        }

        #region IGeneralContext

        public Settings Settings { get; }

        public IReadOnlyDictionary<string, DocItem> Items { get; }

        public IReadOnlyDictionary<string, IElementWriter> Elements { get; }

        public IContext GetContext(DocItem item) => _contexts.TryGetValue(item.GetType(), out Context context) ? context : null;

        public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, i =>
        {
            string fileName = (GetContext(item)?.FileNameFactory ?? FileNameFactory).GetFileName(this, i);
            return _pathCleaner.Clean(Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileName);
        });

        public string GetUrl(DocItem item) => _urls.GetOrAdd(item.Id, _ => _urlFactory(item));

        public string GetUrl(string id) => Items.TryGetValue(id, out DocItem item) ? GetUrl(item) : _urls.GetOrAdd(id, static i =>
        {
            i = i.Substring(2);
            int parametersIndex = i.IndexOf("(", StringComparison.Ordinal);
            if (parametersIndex > 0)
            {
                string methodName = i.Substring(0, parametersIndex);

                i = $"{methodName}#{i.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
            }

            return "https://docs.microsoft.com/en-us/dotnet/api/" + i.Replace('`', '-');
        });

        public bool HasOwnPage(DocItem item) => item switch
        {
            AssemblyDocItem when !string.IsNullOrEmpty(Settings.AssemblyPageName) || item.Documentation != null || Items.Values.Where(i => i.Parent == item).Skip(1).Any() => true,
            _ => (Settings.GeneratedPages & item.Page) != 0
        };

        #endregion
    }
}
