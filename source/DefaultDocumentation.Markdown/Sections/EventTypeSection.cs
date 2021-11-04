using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeSection : ISectionWriter
    {
        public string Name => "EventType";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is EventDocItem eventItem)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .AppendLine("#### Event Type")
                    .AppendLink(eventItem, eventItem.Event.ReturnType);
            }
        }
    }
}
