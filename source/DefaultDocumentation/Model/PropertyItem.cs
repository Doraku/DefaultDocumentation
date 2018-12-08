using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyItem : ADocItem, ITitleDocItem
    {
        public const string Id = "P:";

        public string Title => "property";

        public PropertyItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
