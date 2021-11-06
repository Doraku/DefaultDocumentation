using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SummarySectionTest : ASectionTest<SummarySection>
    {
        [Fact]
        public void Name_should_be_summary() => Check.That(Name).IsEqualTo("summary");

        [Fact]
        public void Write_should_not_write_When_not_present() => Test(
            AssemblyInfo.ClassDocItem,
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "test"))),
            "test");

        [Fact]
        public void Write_should_write_unhandled_element() => Test(
            new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", new XElement("test", "test")))),
            "<test>test</test>");

        [Fact]
        public void Write_should_write_and_ignore_leading_empty_lines() => Test(
            new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "\ntest"))),
            "test");

        [Fact]
        public void Write_should_not_write_When_TypeParameterDocItem_and_no_documentation() => Test(
            new ClassDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.ClassWithTypeParameterDocItem.Type, new XElement("doc", new XElement("typeparam", "invalid"))).TypeParameters.Single(),
            string.Empty);

        [Fact]
        public void Write_should_write_When_TypeParameterDocItem() => Test(
            new ClassDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.ClassWithTypeParameterDocItem.Type, new XElement("doc", new XElement("typeparam", new XAttribute("name", "T"), "test"))).TypeParameters.Single(),
            "test");

        [Fact]
        public void Write_should_not_write_When_ParameterDocItem_and_not_documentation() => Test(
            new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithParameterDocItem.Method, new XElement("doc", new XElement("param", "invalid"))).Parameters.Single(),
            string.Empty);

        [Fact]
        public void Write_should_write_When_ParameterDocItem() => Test(
            new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithParameterDocItem.Method, new XElement("doc", new XElement("param", "invalid"), new XElement("param", new XAttribute("name", "parameter"), "test"))).Parameters.Single(),
            "test");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "test"))),
            w => w.Append("pouet"),
@"pouet

test");
    }
}
