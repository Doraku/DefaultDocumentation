using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.InterfacesSectionTests;

public sealed class NameShould : BaseSectionTester<InterfacesSection>
{
    [Fact]
    public void ReturnInterfaces() => Check.That(Name).IsEqualTo("Interfaces");
}
