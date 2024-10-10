using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.InheritanceSectionTests;

public sealed class NameShould : BaseSectionTester<InheritanceSection>
{
    [Fact]
    public void ReturnInheritance() => Check.That(Name).IsEqualTo("Inheritance");
}
