using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.RemarksSectionTests;

public sealed class WriteShould : BaseSectionTester<RemarksSection>
{
    [Fact]
    public void NotWriteWhenNotPresent() => Test(
        AssemblyInfo.ClassDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("remarks", "test"))),
@"### Remarks
test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        new ClassDocItem(AssemblyInfo.NamespaceDocItem, AssemblyInfo.ClassDocItem.Type, new XElement("doc", new XElement("remarks", "test"))),
        w => w.Append("pouet"),
@"pouet

### Remarks
test");
}
