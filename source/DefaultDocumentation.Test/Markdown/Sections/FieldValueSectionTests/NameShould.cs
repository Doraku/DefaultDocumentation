using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.FieldValueSectionTests;

public sealed class NameShould : BaseSectionTester<FieldValueSection>
{
    [Fact]
    public void ReturnFieldValue() => Check.That(Name).IsEqualTo("FieldValue");
}
