using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ValueItem : AItem
    {
        public override string Header => "Value";

        public ValueItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
