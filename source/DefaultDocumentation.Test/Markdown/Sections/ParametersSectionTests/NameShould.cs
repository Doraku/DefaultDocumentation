using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ParametersSectionTests;

public sealed class NameShould : BaseSectionTester<ParametersSection>
{
    [Fact]
    public void ReturnParameters() => Check.That(Name).IsEqualTo("Parameters");
}
