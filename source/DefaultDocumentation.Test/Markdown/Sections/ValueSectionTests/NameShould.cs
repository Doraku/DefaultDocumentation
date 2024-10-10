using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ValueSectionTests;

public sealed class NameShould : BaseSectionTester<ValueSection>
{
    [Fact]
    public void ReturnValue() => Check.That(Name).IsEqualTo("value");
}
