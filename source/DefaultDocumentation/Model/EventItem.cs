using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class EventItem : AMemberItem
    {
        public const string Id = "E:";

        public override string Header => "Events";
        public override string Title => "event";

        public EventItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
