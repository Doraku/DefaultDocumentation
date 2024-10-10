using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ConstructorsSectionTests;

public sealed class NameShould : BaseSectionTester<ConstructorsSection>
{
    [Fact]
    public void ReturnConstructors() => Check.That(Name).IsEqualTo("Constructors");
}
