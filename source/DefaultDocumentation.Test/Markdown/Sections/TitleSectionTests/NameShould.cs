using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.TitleSectionTests;

public sealed class NameShould : BaseSectionTester<TitleSection>
{
    [Fact]
    public void ReturnTitle() => Check.That(Name).IsEqualTo("Title");
}
