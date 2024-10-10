using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.StructsSectionTests;

public sealed class NameShould : BaseSectionTester<StructsSection>
{
    [Fact]
    public void ReturnStructs() => Check.That(Name).IsEqualTo("Structs");
}
