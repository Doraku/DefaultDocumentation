using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyItem : AMemberItem
    {
        public const string Id = "P:";

        public override string Header => "Properties";
        public override string Title => "property";

        public ValueItem Value { get; }

        public PropertyItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            XElement valueElement = element.GetValue();
            Value = valueElement != null ? new ValueItem(this, valueElement) : null;
        }
    }
}
