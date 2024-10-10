using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.SummarySectionTests;

public sealed class NameShould : BaseSectionTester<SummarySection>
{
    [Fact]
    public void ReturnSummary() => Check.That(Name).IsEqualTo("summary");
}
