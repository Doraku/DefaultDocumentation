using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class ParamRefWriterTest : AElementWriterTest<ParamRefWriter>
    {
        private readonly DocItem _item;

        public ParamRefWriterTest()
        {
            _item = Substitute.For<DocItem, ITypeParameterizedDocItem>(null, "test", "test", "test", null);
            ITypeParameter parameter = Substitute.For<ITypeParameter>();
            parameter.Name.Returns("dummy");
            ((ITypeParameterizedDocItem)_item).TypeParameters.Returns(new[]
            {
                new TypeParameterDocItem(_item, parameter, null)
            });
        }

        [Fact]
        public void Name_should_be_paramref() => Check.That(Name).IsEqualTo("paramref");

        [Fact]
        public void Write_should_write() => Test(
            _item,
            new XElement("paramref", new XAttribute("name", "dummy")),
            "[dummy]()");
    }
}
