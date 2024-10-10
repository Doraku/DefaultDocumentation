using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.RemarksSectionTests;

public sealed class NameShould : BaseSectionTester<RemarksSection>
{
    [Fact]
    public void ReturnRemarks() => Check.That(Name).IsEqualTo("remarks");
}
