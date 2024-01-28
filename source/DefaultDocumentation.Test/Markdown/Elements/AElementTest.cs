using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Models;
using NFluent;

namespace DefaultDocumentation.Markdown.Elements
{
    public abstract class AElementTest<T> : AWriterTest
        where T : IElement, new()
    {
        private readonly T _elementWriter;

        public string Name => _elementWriter.Name;

        protected AElementTest()
        {
            _elementWriter = new T();
        }

        protected void Test(DocItem item, Func<IWriter, IWriter> initializer, XElement input, string? expectedOutput)
        {
            _builder.Clear();
            IWriter writer = initializer(new PageWriter(_builder, new PageContext(_context.Value, item)));

            _elementWriter.Write(writer, input);

            Check.That(_builder.ToString()).IsEqualTo(expectedOutput);
        }

        protected void Test(Func<IWriter, IWriter> initializer, XElement input, string? expectedOutput) => Test(_docItem, initializer, input, expectedOutput);

        protected void Test(DocItem item, XElement input, string? expectedOutput) => Test(item, static w => w, input, expectedOutput);

        protected void Test(XElement input, string? expectedOutput) => Test(_docItem, input, expectedOutput);
    }
}
