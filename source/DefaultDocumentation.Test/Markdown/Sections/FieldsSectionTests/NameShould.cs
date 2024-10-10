using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.FieldsSectionTests;

public sealed class NameShould : BaseSectionTester<FieldsSection>
{
    [Fact]
    public void ReturnFields() => Check.That(Name).IsEqualTo("Fields");
}
