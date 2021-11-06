using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Members;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class EventTypeSection : ISection
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
