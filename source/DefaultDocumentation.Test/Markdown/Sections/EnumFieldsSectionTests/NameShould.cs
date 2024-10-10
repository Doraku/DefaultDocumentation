using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EnumFieldsSectionTests;

public sealed class NameShould : BaseSectionTester<EnumFieldsSection>
{
    [Fact]
    public void ReturnEnumFields() => Check.That(Name).IsEqualTo("EnumFields");
}
