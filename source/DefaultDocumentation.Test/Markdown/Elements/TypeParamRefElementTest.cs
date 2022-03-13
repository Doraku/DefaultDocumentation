using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class TypeParamRefElementTest : AElementTest<TypeParamRefElement>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() => AssemblyInfo.ClassWithTypeParameterDocItem.TypeParameters.AsEnumerable<DocItem>().ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_typeparamref() => Check.That(Name).IsEqualTo("typeparamref");

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.ClassWithTypeParameterDocItem,
            new XElement("typeparamref", new XAttribute("name", "T")),
            "[T](T:DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter`1.T 'DefaultDocumentation.AssemblyInfo.ClassWithTypeParameter<T>.T')");

        [Fact]
        public void Write_should_write_name_When_not_found() => Test(
            new XElement("typeparamref", new XAttribute("name", "unknown")),
            "unknown");
    }
}
