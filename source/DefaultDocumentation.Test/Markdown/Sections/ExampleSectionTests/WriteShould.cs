using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExampleSectionTests;

public sealed class WriteShould : BaseSectionTester<ExampleSection>
{
    [Fact]
    public void NotWriteWhenNotPresent() => Test(
        AssemblyInfo.ClassDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("example", "test"))),
@"### Example
test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("example", "test"))),
        w => w.Append("pouet"),
@"pouet

### Example
test");
}
