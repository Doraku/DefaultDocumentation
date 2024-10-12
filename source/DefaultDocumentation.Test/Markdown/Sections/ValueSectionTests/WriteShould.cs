using System.Xml.Linq;
using DefaultDocumentation.Models.Members;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ValueSectionTests;

public sealed class WriteShould : BaseSectionTester<ValueSection>
{
    [Fact]
    public void NotWriteWhenNotPropertyDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.PropertyDocItem,
@"#### Property Value
[System\.Int32](T:System.Int32 'System\.Int32')");

    [Fact]
    public void WriteValueWhenPresent() => Test(
        new PropertyDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.PropertyDocItem.Property, new XElement("doc", new XElement("value", "test"))),
@"#### Property Value
[System\.Int32](T:System.Int32 'System\.Int32')  
test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.PropertyDocItem,
        w => w.Append("pouet"),
@"pouet

#### Property Value
[System\.Int32](T:System.Int32 'System\.Int32')");
}
