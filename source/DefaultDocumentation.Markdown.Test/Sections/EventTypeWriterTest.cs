using System;
using DefaultDocumentation.Model;
using DefaultDocumentation.Model.Member;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeWriterTest : ASectionWriterTest<EventTypeWriter>
    {
        private static event Action _event;

        [Fact]
        public void Name_should_be_EventType() => Check.That(Name).IsEqualTo("EventType");

        [Fact]
        public void Write_should_not_write_When_not_EventDocItem() => Test(
            default(DocItem),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            new EventDocItem(null, AssemblyInfo.Get<IEvent>($"E:{typeof(EventTypeWriterTest).FullName}.{nameof(_event)}"), null),
@"#### Event Type
[System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            new EventDocItem(null, AssemblyInfo.Get<IEvent>($"E:{typeof(EventTypeWriterTest).FullName}.{nameof(_event)}"), null),
            w => w.Append("pouet"),
@"pouet

#### Event Type
[System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')");
    }
}
