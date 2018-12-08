using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class EventItem : ADocItem,  ITitleDocItem
    {
        public const string Id = "E:";

        public string Title => "event";

        public EventItem(ADocItem parent, XElement element)
            : base(parent, element)
        {
        }
    }
}
