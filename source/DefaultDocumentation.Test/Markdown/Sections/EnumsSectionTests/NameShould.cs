using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EnumsSectionTests;

public sealed class NameShould : BaseSectionTester<EnumsSection>
{
    [Fact]
    public void ReturnEnums() => Check.That(Name).IsEqualTo("Enums");
}
