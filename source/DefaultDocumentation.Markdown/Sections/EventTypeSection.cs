using DefaultDocumentation.Api;
using DefaultDocumentation.Models.Members;

namespace DefaultDocumentation.Markdown.Sections
{
    /// <summary>
    /// <see cref="ISection"/> implementation to write the event type of <see cref="EventDocItem"/>.
    /// </summary>
    public sealed class EventTypeSection : ISection
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "EventType";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
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
