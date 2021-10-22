using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeWriter : ISectionWriter
    {
        public string Name => "EventType";

        public void Write(IWriter writer)
        {
            if (writer.CurrentItem is EventDocItem eventItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLine("#### Event Type")
                    .AppendLink(eventItem, eventItem.Event.ReturnType);
            }
        }
    }
}
