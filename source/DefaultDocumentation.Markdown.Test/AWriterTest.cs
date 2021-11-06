using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
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
                IReadOnlyDictionary<string, IElement> elements,
                IEnumerable<ISection> sections)
            {
                Settings = settings;
                Items = items;
                Elements = elements;
                FileNameFactory = fileNameFactory;
                Sections = sections;
            }

            public Settings Settings { get; }

            public IReadOnlyDictionary<string, DocItem> Items { get; }

            public IReadOnlyDictionary<string, IElement> Elements { get; }

            public IFileNameFactory FileNameFactory { get; }

            public IEnumerable<ISection> Sections { get; }

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
                GetElements(),
                GetSections()));
        }

        protected virtual GeneratedPages GetGeneratedPages() => GeneratedPages.Default;

        protected virtual IFileNameFactory GetFileNameFactory() => new FileNameFactory();

        protected virtual ISection[] GetSections() => Array.Empty<ISection>();

        protected virtual IReadOnlyDictionary<string, IElement> GetElements() => new Dictionary<string, IElement>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();
    }
}
