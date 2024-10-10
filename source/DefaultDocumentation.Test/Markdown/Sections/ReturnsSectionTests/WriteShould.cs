using System.Xml.Linq;
using DefaultDocumentation.Models.Members;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ReturnsSectionTests;

public sealed class WriteShould : BaseSectionTester<ReturnsSection>
{
    [Fact]
    public void NotWriteWhenNotCorrectDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
        string.Empty);

    [Fact]
    public void NotWriteWhenReturnsVoid() => Test(
        AssemblyInfo.ExplicitMethodDocItem,
        string.Empty);

    [Fact]
    public void WriteWhenDelegateDocItem() => Test(
        AssemblyInfo.DelegateDocItem,
@"#### Returns
[System.Int32](T:System.Int32 'System.Int32')");

    [Fact]
    public void WriteWhenMethodDocItem() => Test(
        AssemblyInfo.MethodWithReturnDocItem,
@"#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')");

    [Fact]
    public void WriteWhenOperatorDocItem() => Test(
        AssemblyInfo.OperatorDocItem,
@"#### Returns
[System.Int32](T:System.Int32 'System.Int32')");

    [Fact]
    public void WriteWhenPresent() => Test(
        new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.MethodWithReturnDocItem.Method, new XElement("doc", new XElement("returns", "test"))),
@"#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')  
test");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.MethodWithReturnDocItem,
        w => w.Append("pouet"),
@"pouet

#### Returns
[System.Boolean](T:System.Boolean 'System.Boolean')");
}
