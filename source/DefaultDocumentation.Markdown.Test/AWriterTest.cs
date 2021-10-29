using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultDocumentation.Markdown.FileNameFactories;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown
{
    public abstract class AWriterTest
    {
        protected readonly StringBuilder _builder;
        protected readonly DocItem _docItem;
        protected readonly Lazy<Settings> _settings;
        protected readonly Lazy<DocumentationContext> _context;

        protected AWriterTest()
        {
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _settings = new Lazy<Settings>(() => new Settings(
                null,
                null,
                "test.dll",
                null,
                Path.GetTempPath(),
                null,
                null,
                null,
                null,
                false,
                NestedTypeVisibilities.Default,
                GetGeneratedPages(),
                GeneratedAccessModifiers.Default,
                false,
                false,
                null,
                null,
                null));
            _context = new Lazy<DocumentationContext>(() => new DocumentationContext(
                _settings.Value,
                new FullNameFactory(),
                GetSectionWriters(),
                GetElementWriters(),
                GetItems()));
        }

        protected virtual GeneratedPages GetGeneratedPages() => GeneratedPages.Default;

        protected virtual ISectionWriter[] GetSectionWriters() => Array.Empty<ISectionWriter>();

        protected virtual IReadOnlyDictionary<string, IElementWriter> GetElementWriters() => new Dictionary<string, IElementWriter>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();
    }
}
