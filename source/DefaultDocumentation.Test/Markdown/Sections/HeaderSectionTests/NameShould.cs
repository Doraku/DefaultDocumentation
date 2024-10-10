using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.HeaderSectionTests;

public sealed class NameShould : BaseSectionTester<HeaderSection>
{
    [Fact]
    public void ReturnHeader() => Check.That(Name).IsEqualTo("Header");
}
