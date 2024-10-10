using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DefinitionSectionTests;

public sealed class NameShould : BaseSectionTester<DefinitionSection>
{
    [Fact]
    public void ReturnDefinition() => Check.That(Name).IsEqualTo("Definition");
}
