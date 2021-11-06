using System.Xml.Linq;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElementTest : AElementTest<TypeParamRefElement>
    {
        [Fact]
        public void Name_should_be_typeparamref() => Check.That(Name).IsEqualTo("typeparamref");

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.ClassWithTypeParameterDocItem,
            new XElement("typeparamref", new XAttribute("name", "T")),
            "[T](T 'DefaultDocumentation.Markdown.AssemblyInfo.ClassWithTypeParameter<T>.T')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("typeparamref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
