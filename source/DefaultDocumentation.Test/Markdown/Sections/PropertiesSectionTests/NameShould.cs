using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.PropertiesSectionTests;

public sealed class NameShould : BaseSectionTester<PropertiesSection>
{
    [Fact]
    public void ReturnProperties() => Check.That(Name).IsEqualTo("Properties");
}
