using System.Xml.Linq;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElementTest : AElementTest<TypeParamRefElement>
    {
        private static class Dummy<T>
        { }

        private readonly DocItem _item;

        public TypeParamRefElementTest()
        {
            _item = new ClassDocItem(null, AssemblyInfo.Get<ITypeDefinition>($"T:{typeof(TypeParamRefElementTest).FullName}.Dummy`1"), null);
        }

        [Fact]
        public void Name_should_be_typeparamref() => Check.That(Name).IsEqualTo("typeparamref");

        [Fact]
        public void Write_should_write() => Test(
            _item,
            new XElement("typeparamref", new XAttribute("name", "T")),
            "[T](T 'DefaultDocumentation.Markdown.Elements.TypeParamRefElementTest.Dummy&lt;T&gt;.T')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("typeparamref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
