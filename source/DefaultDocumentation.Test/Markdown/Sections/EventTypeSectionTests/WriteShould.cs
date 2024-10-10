using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EventTypeSectionTests;

public sealed class WriteShould : BaseSectionTester<EventTypeSection>
{
    [Fact]
    public void NotWriteWhenNotEventDocItem() => Test(
        AssemblyInfo.AssemblyDocItem,
        string.Empty);

    [Fact]
    public void Write() => Test(
        AssemblyInfo.EventDocItem,
@"#### Event Type
[System.Action](T:System.Action 'System.Action')");

    [Fact]
    public void WriteNewlineWhenNeeded() => Test(
        AssemblyInfo.EventDocItem,
        w => w.Append("pouet"),
@"pouet

#### Event Type
[System.Action](T:System.Action 'System.Action')");
}
