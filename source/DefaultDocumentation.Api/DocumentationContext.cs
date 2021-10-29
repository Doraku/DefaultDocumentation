using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation
{
    public sealed class DocumentationContext
    {
        private readonly IReadOnlyDictionary<string, DocItem> _items;
        private readonly IFileNameFactory _fileNameFactory;
        private readonly ConcurrentDictionary<DocItem, string> _fileNames;
        private readonly ConcurrentDictionary<string, string> _urls;
        private readonly Func<DocItem, string> _urlFactory;
        private readonly PathCleaner _pathCleaner;

        public Settings Settings { get; }

        public IEnumerable<ISectionWriter> SectionWriters { get; }

        public IReadOnlyDictionary<string, IElementWriter> ElementWriters { get; }

        public IEnumerable<DocItem> Items => _items.Values;

        public DocumentationContext(Settings settings, IFileNameFactory fileNameFactory, IEnumerable<ISectionWriter> sectionWriters, IReadOnlyDictionary<string, IElementWriter> elementWriters, IReadOnlyDictionary<string, DocItem> items)
        {
            Settings = settings;
            _fileNameFactory = fileNameFactory;
            SectionWriters = sectionWriters.ToArray();
            ElementWriters = elementWriters;
            _items = items;
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
            _pathCleaner = new PathCleaner(settings.InvalidCharReplacement);
        }

        public string GetFileName(DocItem item) => _fileNames.GetOrAdd(item, i =>
        {
            string fileName = _fileNameFactory.GetFileName(this, i);
            return _pathCleaner.Clean(Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileName);
        });

        public string GetUrl(DocItem item) => _urls.GetOrAdd(item.Id, _ => _urlFactory(item));

        public string GetUrl(string id) => TryGetDocItem(id, out DocItem item) ? GetUrl(item) : _urls.GetOrAdd(id, static i =>
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

        public bool TryGetDocItem(string id, out DocItem item) => _items.TryGetValue(id, out item);

        public bool HasOwnPage(DocItem item) => item switch
        {
            AssemblyDocItem when !string.IsNullOrEmpty(Settings.AssemblyPageName) || item.Documentation != null || GetChildren<NamespaceDocItem>(item).Skip(1).Any() => true,
            _ => (Settings.GeneratedPages & item.Page) != 0
        };

        public IEnumerable<T> GetChildren<T>(DocItem item)
            where T : DocItem
        {
            IEnumerable<DocItem> GetAllChildren(DocItem item)
            {
                foreach (DocItem child in Items.Where(i => i.Parent == item))
                {
                    yield return child;
                    foreach (DocItem indirectChild in GetAllChildren(child))
                    {
                        yield return indirectChild;
                    }
                }
            }

            return (item switch
            {
                NamespaceDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (Settings.NestedTypeVisibilities & NestedTypeVisibilities.Namespace) != 0 => GetAllChildren(item),
                TypeDocItem when typeof(T).IsSubclassOf(typeof(TypeDocItem)) && (Settings.NestedTypeVisibilities & NestedTypeVisibilities.DeclaringType) == 0 => Enumerable.Empty<T>(),
                _ => Items.Where(i => i.Parent == item)
            }).OfType<T>().OrderBy(c => c.FullName);
        }
    }
}
