using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;
using NFluent;

namespace DefaultDocumentation.Markdown.Sections
{
    public abstract class ASectionWriterTest<T>
        where T : ISectionWriter, new()
    {
        private readonly StringBuilder _builder;
        private readonly DocItem _docItem;
        private readonly Settings _settings;
        private readonly Lazy<DocumentationContext> _context;
        private readonly T _sectionWriter;

        protected readonly string _tempFolder;

        public string Name => _sectionWriter.Name;

        protected ASectionWriterTest()
        {
            _tempFolder = Path.GetTempPath();
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _settings = new Settings(null, null, "test.dll", null, _tempFolder, null, null, null, FileNameMode.FullName, false, NestedTypeVisibilities.Default, GeneratedPages.Default, GeneratedAccessModifiers.Default, false, false, null, null, null);
            _context = new Lazy<DocumentationContext>(() => new DocumentationContext(
                _settings,
                GetSectionWriters(),
                GetElementWriters(),
                GetItems()));
            _sectionWriter = new T();
        }

        protected virtual ISectionWriter[] GetSectionWriters() => Array.Empty<ISectionWriter>();

        protected virtual IReadOnlyDictionary<string, IElementWriter> GetElementWriters() => new Dictionary<string, IElementWriter>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();

        protected void Test(DocItem item, Func<IWriter, IWriter> initializer, string expectedOutput)
        {
            _builder.Clear();
            IWriter writer = initializer(new PageWriter(_builder, _context.Value, item));

            _sectionWriter.Write(writer);

            Check.That(_builder.ToString()).IsEqualTo(expectedOutput);
        }

        protected void Test(Func<IWriter, IWriter> initializer, string expectedOutput) => Test(_docItem, initializer, expectedOutput);

        protected void Test(DocItem item, string expectedOutput) => Test(item, static w => w, expectedOutput);

        protected void Test(string expectedOutput) => Test(_docItem, expectedOutput);
    }
}
