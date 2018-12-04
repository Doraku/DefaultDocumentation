using System.Xml.Linq;

namespace DefaultApiReference.Model
{
    internal sealed class PropertyItem : ADocItem, ITitleDocItem
    {
        public const string Id = "P:";

        public string Title => "property";

        public PropertyItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
