using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;
using NFluent;

namespace DefaultDocumentation.Markdown.Elements
{
    public abstract class AElementWriterTest<T>
        where T : IElementWriter, new()
    {
        private readonly StringBuilder _builder;
        private readonly DocItem _docItem;
        private readonly Settings _settings;
        private readonly DocumentationContext _context;
        private readonly T _elementWriter;

        protected readonly string _tempFolder;

        public string Name => _elementWriter.Name;

        protected AElementWriterTest()
        {
            _tempFolder = Path.GetTempPath();
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _settings = new Settings(null, null, "test.dll", null, _tempFolder, null, null, null, FileNameMode.FullName, false, NestedTypeVisibilities.Default, GeneratedPages.Default, GeneratedAccessModifiers.Default, false, false, null, null, null);
            _context = new DocumentationContext(
                _settings,
                GetSectionWriters(),
                GetElementWriters(),
                GetItems());
            _elementWriter = new T();
        }

        protected virtual ISectionWriter[] GetSectionWriters() => Array.Empty<ISectionWriter>();

        protected virtual IReadOnlyDictionary<string, IElementWriter> GetElementWriters() => new Dictionary<string, IElementWriter>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();

        protected void Test(DocItem item, Func<IWriter, IWriter> initializer, XElement input, string expectedOutput)
        {
            _builder.Clear();
            IWriter writer = initializer(new PageWriter(_builder, _context, item));

            _elementWriter.Write(writer, input);

            Check.That(_builder.ToString()).IsEqualTo(expectedOutput);
        }

        protected void Test(Func<IWriter, IWriter> initializer, XElement input, string expectedOutput) => Test(_docItem, initializer, input, expectedOutput);

        protected void Test(DocItem item, XElement input, string expectedOutput) => Test(item, static w => w, input, expectedOutput);

        protected void Test(XElement input, string expectedOutput) => Test(_docItem, input, expectedOutput);
    }
}
