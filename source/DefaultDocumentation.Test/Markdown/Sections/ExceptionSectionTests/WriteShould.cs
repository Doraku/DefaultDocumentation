using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExceptionSectionTests;

public sealed class WriteShould : BaseSectionTester<ExceptionSection>
{
    [Fact]
    public void NotWriteWhenNotPresent() => Test(
        AssemblyInfo.ClassDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
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
    public void WriteNewlineWhenNeeded() => Test(
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
