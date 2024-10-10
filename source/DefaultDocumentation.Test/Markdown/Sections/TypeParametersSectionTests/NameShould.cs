using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.TypeParametersSectionTests;

public sealed class NameShould : BaseSectionTester<TypeParametersSection>
{
    [Fact]
    public void ReturnTypeParameters() => Check.That(Name).IsEqualTo("TypeParameters");
}
