using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DefaultSectionTests;

public sealed class WriteShould : BaseSectionTester<DefaultSection>
{
    [Fact]
    public void Write() => Test(string.Empty);
}
