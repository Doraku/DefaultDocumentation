using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ImplementSectionTests;

public sealed class NameShould : BaseSectionTester<ImplementSection>
{
    [Fact]
    public void ReturnImplement() => Check.That(Name).IsEqualTo("Implement");
}
