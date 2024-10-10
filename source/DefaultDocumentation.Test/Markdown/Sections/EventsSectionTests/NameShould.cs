using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EventsSectionTests;

public sealed class NameShould : BaseSectionTester<EventsSection>
{
    [Fact]
    public void ReturnEvents() => Check.That(Name).IsEqualTo("Events");
}
