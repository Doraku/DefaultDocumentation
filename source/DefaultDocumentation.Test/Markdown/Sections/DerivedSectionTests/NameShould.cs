using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DerivedSectionTests;

public sealed class NameShould : BaseSectionTester<DerivedSection>
{
    [Fact]
    public void ReturnDerived() => Check.That(Name).IsEqualTo("Derived");
}
