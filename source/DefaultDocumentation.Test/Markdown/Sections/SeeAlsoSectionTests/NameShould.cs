using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.SeeAlsoSectionTests;

public sealed class NameShould : BaseSectionTester<SeeAlsoSection>
{
    [Fact]
    public void ReturnSeealso() => Check.That(Name).IsEqualTo("seealso");
}
