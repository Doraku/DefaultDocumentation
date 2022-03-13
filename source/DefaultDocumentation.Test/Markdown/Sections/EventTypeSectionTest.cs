using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeSectionTest : ASectionTest<EventTypeSection>
    {
        [Fact]
        public void Name_should_be_EventType() => Check.That(Name).IsEqualTo("EventType");

        [Fact]
        public void Write_should_not_write_When_not_EventDocItem() => Test(
            default(DocItem),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.EventDocItem,
@"#### Event Type
[System.Action](T:System.Action 'System.Action')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.EventDocItem,
            w => w.Append("pouet"),
@"pouet

#### Event Type
[System.Action](T:System.Action 'System.Action')");
    }
}
