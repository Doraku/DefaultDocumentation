using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.DelegatesSectionTests;

public sealed class NameShould : BaseSectionTester<DelegatesSection>
{
    [Fact]
    public void ReturnDelegates() => Check.That(Name).IsEqualTo("Delegates");
}
