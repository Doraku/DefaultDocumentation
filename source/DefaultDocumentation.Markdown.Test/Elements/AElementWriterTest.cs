using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writer;
using NFluent;

namespace DefaultDocumentation.Markdown.Elements
{
    public abstract class AElementWriterTest<T>
        where T : IElementWriter, new()
    {
        private readonly StringBuilder _builder;
        private readonly DocItem _docItem;
        private readonly PageWriter _writer;
        private readonly T _elementWriter;

        public string Name => _elementWriter.Name;

        public AElementWriterTest()
        {
            _builder = new StringBuilder();
            _docItem = new ExternDocItem("test", "test", "test");
            _writer = new PageWriter(
                new DocumentationContext(
                    new Settings(null, null, "test.dll", null, null, null, null, null, FileNameMode.FullName, false, NestedTypeVisibilities.Default, GeneratedPages.Default, GeneratedAccessModifiers.Default, false, false, null, null, null),
                    GetSectionWriters(),
                    GetElementWriters(),
                    GetItems()),
                _builder,
                _docItem);
            _elementWriter = new T();
        }

        protected virtual ISectionWriter[] GetSectionWriters() => Array.Empty<ISectionWriter>();

        protected virtual IReadOnlyDictionary<string, IElementWriter> GetElementWriters() => new Dictionary<string, IElementWriter>();

        protected virtual IReadOnlyDictionary<string, DocItem> GetItems() => new Dictionary<string, DocItem>();

        protected void Test(DocItem item, Action<PageWriter> initializer, XElement input, string expectedOutput)
        {
            _builder.Clear();
            PageWriter writer = _writer.With(item);
            initializer(writer);

            _elementWriter.Write(writer, input);

            Check.That(_builder.ToString()).IsEqualTo(expectedOutput);
        }

        protected void Test(Action<PageWriter> initializer, XElement input, string expectedOutput) => Test(_docItem, initializer, input, expectedOutput);

        protected void Test(DocItem item, XElement input, string expectedOutput) => Test(item, static _ => { }, input, expectedOutput);

        protected void Test(XElement input, string expectedOutput) => Test(_docItem, input, expectedOutput);
    }
}
