using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.ExampleSectionTests;

public sealed class NameShould : BaseSectionTester<ExampleSection>
{
    [Fact]
    public void ReturnExample() => Check.That(Name).IsEqualTo("example");
}
