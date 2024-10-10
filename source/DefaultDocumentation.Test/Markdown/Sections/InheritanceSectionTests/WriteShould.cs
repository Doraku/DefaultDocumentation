using Xunit;

namespace DefaultDocumentation.Markdown.Sections.InheritanceSectionTests;

public sealed class WriteShould : BaseSectionTester<InheritanceSection>
{
    [Fact]
    public void NotWriteWhenNotTypeDocItem() => Test(string.Empty);

    [Fact]
    public void NotWriteWhenStructDocItem() => Test(
        AssemblyInfo.StructDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.ClassDocItem,
        "Inheritance [System.Object](T:System.Object 'System.Object') &#129106; AssemblyInfo");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.ClassDocItem,
        w => w.Append("pouet"),
@"pouet

Inheritance [System.Object](T:System.Object 'System.Object') &#129106; AssemblyInfo");
}
