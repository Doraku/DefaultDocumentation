using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.FooterSectionTests;

public sealed class NameShould : BaseSectionTester<FooterSection>
{
    [Fact]
    public void ReturnFooter() => Check.That(Name).IsEqualTo("Footer");
}
