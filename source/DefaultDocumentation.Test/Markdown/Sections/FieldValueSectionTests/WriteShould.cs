using Xunit;

namespace DefaultDocumentation.Markdown.Sections.FieldValueSectionTests;

public sealed class WriteShould : BaseSectionTester<FieldValueSection>
{
    [Fact]
    public void NotWriteWhenNotFieldDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.FieldDocItem,
@"#### Field Value
[System.Int32](T:System.Int32 'System.Int32')");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.FieldDocItem,
        w => w.Append("pouet"),
@"pouet

#### Field Value
[System.Int32](T:System.Int32 'System.Int32')");
}
