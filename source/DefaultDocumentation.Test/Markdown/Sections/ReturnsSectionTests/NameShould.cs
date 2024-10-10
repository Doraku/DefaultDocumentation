using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ReturnsSectionTests;

public sealed class NameShould : BaseSectionTester<ReturnsSection>
{
    [Fact]
    public void ReturnReturns() => Check.That(Name).IsEqualTo("returns");
}
