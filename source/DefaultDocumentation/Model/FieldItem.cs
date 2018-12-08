using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldItem : ADocItem, ITitleDocItem
    {
        public const string Id = "F:";

        public string Title => "field";

        public FieldItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
