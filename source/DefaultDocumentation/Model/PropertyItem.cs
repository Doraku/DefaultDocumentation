using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyItem : AMemberItem
    {
        public const string Id = "P:";

        public override string Header => "Properties";
        public override string Title => "property";

        public PropertyItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
