using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExceptionSectionTest : ASectionTest<ExceptionSection>
    {
        [Fact]
        public void Name_should_be_exception() => Check.That(Name).IsEqualTo("exception");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            AssemblyInfo.ClassDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new ClassDocItem(
                AssemblyInfo.NamespaceDocItem,
                AssemblyInfo.ClassDocItem.Type,
                new XElement("doc",
                    new XElement("exception", new XAttribute("cref", "T:System.Exception"), "test"),
                    new XElement("exception", new XAttribute("cref", "T:System.Exception"), "test"))),
@"#### Exceptions

[System.Exception](T:System.Exception 'System.Exception')  
test

[System.Exception](T:System.Exception 'System.Exception')  
test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new ClassDocItem(
                AssemblyInfo.NamespaceDocItem,
                AssemblyInfo.ClassDocItem.Type,
                new XElement("doc", new XElement("exception", new XAttribute("cref", "T:System.Exception"), "test"))),
            w => w.Append("pouet"),
@"pouet

#### Exceptions

[System.Exception](T:System.Exception 'System.Exception')  
test");
    }
}
