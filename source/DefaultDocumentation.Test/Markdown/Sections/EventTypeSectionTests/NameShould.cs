using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections.EventTypeSectionTests;

public sealed class NameShould : BaseSectionTester<EventTypeSection>
{
    [Fact]
    public void ReturnEventType() => Check.That(Name).IsEqualTo("EventType");
}
