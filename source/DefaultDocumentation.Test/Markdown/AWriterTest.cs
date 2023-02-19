using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private sealed class UrlFactory : IUrlFactory
        {
            public string Name { get; }

            public string GetUrl(IGeneralContext context, string id) => id;
        }

        private sealed class GeneralContext : IGeneralContext
        {
            private IEnumerable<IUrlFactory> _urlFactories;

            public GeneralContext(
                ISettings settings,
                IFileNameFactory fileNameFactory,
                IEnumerable<IUrlFactory> urlFactories,
                IReadOnlyDictionary<string, DocItem> items,
                IReadOnlyDictionary<string, IElement> elements,
                IEnumerable<ISection> sections)
            {
                Settings = settings;
                Items = items;
                Elements = elements;
                FileNameFactory = fileNameFactory;
                _urlFactories = urlFactories;
                Sections = sections;
            }

            public ISettings Settings { get; }

            public IReadOnlyDictionary<string, DocItem> Items { get; }

            public IReadOnlyDictionary<string, IElement> Elements { get; }

            public IFileNameFactory FileNameFactory { get; }

            public IEnumerable<ISection> Sections { get; }

            public IContext GetContext(Type type) => this;

            public string GetFileName(DocItem item) => FileNameFactory.GetFileName(this, item);

            public T GetSetting<T>(string name) => name switch
            {
                "Markdown.NestedTypeVisibilities" => (T)(object)(NestedTypeVisibilities.Namespace | NestedTypeVisibilities.DeclaringType),
                _ => default
            };

            public string GetUrl(string id) => _urlFactories.Select(f => f.GetUrl(this, id)).FirstOrDefault(url => url is not null) ?? "";
        }

        protected readonly StringBuilder _builder;
        protected readonly DocItem _docItem;
        protected readonly Lazy<ISettings> _settings;
        protected readonly Lazy<IGeneralContext> _context;

        protected AWriterTest()
        {
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _settings = new Lazy<ISettings>(() =>
            {
                ISettings settings = Substitute.For<ISettings>();

                settings.Logger.Returns(Substitute.For<ILogger>());
                settings.AssemblyFile.Returns(new FileInfo("test.dll"));
                settings.ProjectDirectory.Returns(new DirectoryInfo(Path.GetTempPath()));
                settings.GeneratedPages.Returns(GetGeneratedPages());

                return settings;
            });
            _context = new Lazy<IGeneralContext>(() => new GeneralContext(
                _settings.Value,
                GetFileNameFactory(),
                GetUrlFactories(),
                GetItems(),
                GetElements(),
                GetSections()));
        }

        protected virtual GeneratedPages GetGeneratedPages() => GeneratedPages.Assembly | GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;

        protected virtual IFileNameFactory GetFileNameFactory() => new FileNameFactory();

        protected virtual IUrlFactory[] GetUrlFactories() => new IUrlFactory[]
        {
            new UrlFactory()
        };

        protected virtual ISection[] GetSections() => Array.Empty<ISection>();

        protected virtual IReadOnlyDictionary<string, IElement> GetElements() => new Dictionary<string, IElement>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();
    }
}
