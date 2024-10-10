using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.OperatorsSectionTests;

public sealed class NameShould : BaseSectionTester<OperatorsSection>
{
    [Fact]
    public void ReturnOperators() => Check.That(Name).IsEqualTo("Operators");
}
