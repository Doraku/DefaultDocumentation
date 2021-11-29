using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
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
            Dictionary<string, IElement> elementWriters = availableTypes
                .Where(t => typeof(IElement).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (IElement)Activator.CreateInstance(t))
                .GroupBy(w => w.Name)
                .ToDictionary(w => w.Key, w => w.Last());

            foreach (string element in GetSetting<string[]>(nameof(Elements)) ?? Enumerable.Empty<string>())
            {
                IElement writer = availableTypes
                    .Where(t => typeof(IElement).IsAssignableFrom(t) && !t.IsAbstract && $"{t.FullName} {t.Assembly.GetName().Name}" == element)
                    .Select(t => (IElement)Activator.CreateInstance(t))
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
                while (!pagedItem.HasOwnPage(this))
                {
                    pagedItem = pagedItem.Parent;
                }

                string url = GetFileName(pagedItem);
                if (settings.RemoveFileExtensionFromLinks && Path.HasExtension(url))
                {
                    url = url.Substring(0, url.Length - Path.GetExtension(url).Length);
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

        public ISettings Settings { get; }

        public IReadOnlyDictionary<string, DocItem> Items { get; }

        public IReadOnlyDictionary<string, IElement> Elements { get; }

        public IContext GetContext(DocItem item) => _contexts.TryGetValue(item.GetType(), out Context context) ? context : null;

        public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, i =>
        {
            string fileName = (GetContext(item)?.FileNameFactory ?? FileNameFactory).GetFileName(this, i);

            string extension = Path.HasExtension(fileName) ? Path.GetExtension(fileName) : string.Empty;

            return _pathCleaner.Clean(fileName.Substring(0, fileName.Length - extension.Length)) + extension;
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

        #endregion
    }
}
