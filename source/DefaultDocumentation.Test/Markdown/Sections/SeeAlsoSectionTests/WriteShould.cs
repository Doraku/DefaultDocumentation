using System.Xml.Linq;
using DefaultDocumentation.Models;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.SeeAlsoSectionTests;

public sealed class WriteShould : BaseSectionTester<SeeAlsoSection>
{
    [Fact]
    public void NotWriteWhenNotPresent() => Test(
        AssemblyInfo.AssemblyDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        new AssemblyDocItem(
            "Test",
            "Test",
            new XElement("doc",
                new XElement("seealso", new XAttribute("cref", "T:System.Int32")),
                new XElement("seealso", new XAttribute("href", "dummyurl")),
                new XElement("seealso", new XAttribute("cref", "T:System.Int32"), "test"),
                new XElement("seealso", new XAttribute("href", "dummyurl"), "test"))),
@"### See Also
- [System.Int32](T:System.Int32 'System.Int32')
- [dummyurl](dummyurl 'dummyurl')
- [test](T:System.Int32 'System.Int32')
- [test](dummyurl 'dummyurl')");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        new AssemblyDocItem(
            "Test",
            "Test",
            new XElement("doc", new XElement("seealso", new XAttribute("cref", "T:System.Int32")))),
        w => w.Append("pouet"),
@"pouet

### See Also
- [System.Int32](T:System.Int32 'System.Int32')");
}
