using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultDocumentation.Api;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Models;
using NLog;
using NSubstitute;

namespace DefaultDocumentation.Markdown;

public abstract class BaseWriterTester
{
    private sealed class DummyFileNameFactory : IFileNameFactory
    {
        public string Name { get; } = "Dummy";

        public void Clean(IGeneralContext context)
        { }

        public string GetFileName(IGeneralContext context, DocItem item) => item.Name;
    }

    private sealed class DummyUrlFactory : IUrlFactory
    {
        public string Name { get; } = "Dummy";

        public string GetUrl(IPageContext context, string id) => id;
    }

    private sealed class GeneralContext : IGeneralContext
    {
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
            UrlFactories = urlFactories;
            Sections = sections;
        }

        public ISettings Settings { get; }

        public IReadOnlyDictionary<string, DocItem> Items { get; }

        public IReadOnlyDictionary<string, IElement> Elements { get; }

        public IFileNameFactory FileNameFactory { get; }

        public IEnumerable<IUrlFactory> UrlFactories { get; }

        public IEnumerable<ISection> Sections { get; }

        public IContext GetContext(Type? type) => this;

        public string GetFileName(DocItem item) => FileNameFactory.GetFileName(this, item);

        public T? GetSetting<T>(string name) => name switch
        {
            "Markdown.NestedTypeVisibilities" => (T)(object)(NestedTypeVisibilities.Namespace | NestedTypeVisibilities.DeclaringType),
            _ => default
        };
    }

    protected readonly StringBuilder _builder;
    protected readonly DocItem _docItem;
    protected readonly Lazy<ISettings> _settings;
    protected readonly Lazy<IPageContext> _context;

    protected BaseWriterTester()
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
            settings.GeneratedAccessModifiers.Returns(GetGeneratedAccessModifiers());

            return settings;
        });
        _context = new Lazy<IPageContext>(() => new PageContext(
            new GeneralContext(
                _settings.Value,
                GetFileNameFactory(),
                GetUrlFactories(),
                GetItems(),
                GetElements(),
                GetSections()),
            _docItem));
    }

    protected virtual GeneratedPages GetGeneratedPages() => GeneratedPages.Assembly | GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;

    protected virtual GeneratedAccessModifiers GetGeneratedAccessModifiers() => GeneratedAccessModifiers.Api;

    protected virtual IFileNameFactory GetFileNameFactory() => new DummyFileNameFactory();

    protected virtual IUrlFactory[] GetUrlFactories()
    => [
        new DummyUrlFactory()
    ];

    protected virtual ISection[] GetSections() => [];

    protected virtual IReadOnlyDictionary<string, IElement> GetElements() => new Dictionary<string, IElement>();

    protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();
}
