using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DefaultSectionTests;

public sealed class NameShould : BaseSectionTester<DefaultSection>
{
    [Fact]
    public void ReturnDefault() => Check.That(Name).IsEqualTo("Default");
}
