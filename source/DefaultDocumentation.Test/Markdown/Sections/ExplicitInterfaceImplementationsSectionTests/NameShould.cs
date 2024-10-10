using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExplicitInterfaceImplementationsSectionTests;

public sealed class NameShould : BaseSectionTester<ExplicitInterfaceImplementationsSection>
{
    [Fact]
    public void ReturnExplicitInterfaceImplementations() => Check.That(Name).IsEqualTo("ExplicitInterfaceImplementations");
}
