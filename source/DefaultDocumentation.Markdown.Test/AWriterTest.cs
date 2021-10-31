using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;
using NLog;
using NSubstitute;

namespace DefaultDocumentation.Markdown
{
    public abstract class AWriterTest
    {
        private sealed class FileNameFactory : IFileNameFactory
        {
            public string Name { get; }

            public void Clean(IGeneralContext context)
            { }

            public string GetFileName(IGeneralContext context, DocItem item) => item.Name;
        }

        private sealed class GeneralContext : IGeneralContext
        {
            public GeneralContext(
                Settings settings,
                IFileNameFactory fileNameFactory,
                IReadOnlyDictionary<string, DocItem> items,
                IReadOnlyDictionary<string, IElementWriter> elements,
                IEnumerable<ISectionWriter> sections)
            {
                Settings = settings;
                Items = items;
                Elements = elements;
                FileNameFactory = fileNameFactory;
                Sections = sections;
            }

            public Settings Settings { get; }

            public IReadOnlyDictionary<string, DocItem> Items { get; }

            public IReadOnlyDictionary<string, IElementWriter> Elements { get; }

            public IFileNameFactory FileNameFactory { get; }

            public IEnumerable<ISectionWriter> Sections { get; }

            public IContext GetContext(DocItem item) => null;

            public string GetFileName(DocItem item) => FileNameFactory.GetFileName(this, item);

            public T GetSetting<T>(string name) => default;

            public string GetUrl(DocItem item) => item.Name;

            public string GetUrl(string id)
            {
                if (Items.TryGetValue(id, out DocItem item))
                {
                    return GetUrl(item);
                }

                id = id[2..];
                int parametersIndex = id.IndexOf("(", StringComparison.Ordinal);
                if (parametersIndex > 0)
                {
                    string methodName = id.Substring(0, parametersIndex);

                    id = $"{methodName}#{id.Replace('.', '_').Replace('`', '_').Replace('(', '_').Replace(')', '_')}";
                }

                return "https://docs.microsoft.com/en-us/dotnet/api/" + id.Replace('`', '-');
            }

            public bool HasOwnPage(DocItem item) => item switch
            {
                AssemblyDocItem when !string.IsNullOrEmpty(Settings.AssemblyPageName) || item.Documentation != null || Items.Values.Where(i => i.Parent == item).Skip(1).Any() => true,
                _ => (Settings.GeneratedPages & item.Page) != 0
            };
        }

        protected readonly StringBuilder _builder;
        protected readonly DocItem _docItem;
        protected readonly Lazy<Settings> _settings;
        protected readonly Lazy<IGeneralContext> _context;

        protected AWriterTest()
        {
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _settings = new Lazy<Settings>(() => new Settings(
                Substitute.For<ILogger>(),
                "test.dll",
                null,
                Path.GetTempPath(),
                null,
                null,
                GeneratedAccessModifiers.Default,
                GetGeneratedPages(),
                false,
                null,
                false,
                null,
                null,
                null));
            _context = new Lazy<IGeneralContext>(() => new GeneralContext(
                _settings.Value,
                GetFileNameFactory(),
                GetItems(),
                GetElementWriters(),
                GetSectionWriters()));
        }

        protected virtual GeneratedPages GetGeneratedPages() => GeneratedPages.Default;

        protected virtual IFileNameFactory GetFileNameFactory() => new FileNameFactory();

        protected virtual ISectionWriter[] GetSectionWriters() => Array.Empty<ISectionWriter>();

        protected virtual IReadOnlyDictionary<string, IElementWriter> GetElementWriters() => new Dictionary<string, IElementWriter>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();
    }
}
