using System.Xml.Linq;

namespace DefaultApiDocumentation.Model
{
    internal sealed class FieldItem : ADocItem, ITitleDocItem
    {
        public const string Id = "F:";

        public string Title => "field";

        public FieldItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
