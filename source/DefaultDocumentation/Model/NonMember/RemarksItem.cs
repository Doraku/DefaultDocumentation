using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class RemarksItem : AItem
    {
        public override string Header => "Remarks";

        private RemarksItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }

        public static RemarksItem GetFrom(AMemberItem item)
        {
            XElement remarksElement = item.Element.GetRemarks();
            return remarksElement != null ? new RemarksItem(item, remarksElement) : null;
        }
    }
}
