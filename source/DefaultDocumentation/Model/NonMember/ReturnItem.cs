using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ReturnItem : AItem
    {
        public override string Header => "Returns";

        public ReturnItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
