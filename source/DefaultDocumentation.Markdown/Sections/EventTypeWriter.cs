using DefaultDocumentation.Model.Member;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeWriter : SectionWriter
    {
        public EventTypeWriter()
            : base("eventtype")
        { }

        public override void Write(PageWriter writer)
        {
            if (writer.CurrentItem is EventDocItem eventItem)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("#### Event Type")
                    .AppendLink(eventItem, eventItem.Event.ReturnType)
                    .AppendLine();
            }
        }
    }
}
