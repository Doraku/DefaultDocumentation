using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Models.Types;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.SummarySectionTests;

public sealed class WriteShould : BaseSectionTester<SummarySection>
{
    [Fact]
    public void NotWriteWhenNotPresent() => Test(
        AssemblyInfo.ClassDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "test"))),
        "test");

    [Fact]
    public void WriteUnhandledElement() => Test(
        new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", new XElement("test", "test")))),
        "<test>test</test>");

    [Fact]
    public void WriteAndIgnoreLeadingEmptyLines() => Test(
        new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "\ntest"))),
        "test");

    [Fact]
    public void NotWriteWhenTypeParameterDocItemAndNoDocumentation() => Test(
        new ClassDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.ClassWithTypeParameterDocItem.Type, new XElement("doc", new XElement("typeparam", "invalid"))).TypeParameters.Single(),
        string.Empty);

    [Fact]
    public void WriteWhenTypeParameterDocItem() => Test(
        new ClassDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.ClassWithTypeParameterDocItem.Type, new XElement("doc", new XElement("typeparam", new XAttribute("name", "T"), "test"))).TypeParameters.Single(),
        "test");

    [Fact]
    public void NotWriteWhenParameterDocItemAndNotDocumentation() => Test(
        new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithParameterDocItem.Method, new XElement("doc", new XElement("param", "invalid"))).Parameters.Single(),
        string.Empty);

    [Fact]
    public void WriteWhenParameterDocItem() => Test(
        new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithParameterDocItem.Method, new XElement("doc", new XElement("param", "invalid"), new XElement("param", new XAttribute("name", "parameter"), "test"))).Parameters.Single(),
        "test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        new NamespaceDocItem(AssemblyInfo.AssemblyDocItem, "Test", new XElement("doc", new XElement("summary", "test"))),
        w => w.Append("pouet"),
@"pouet

test");
}
