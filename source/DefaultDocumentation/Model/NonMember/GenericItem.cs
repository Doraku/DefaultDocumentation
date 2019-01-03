using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class GenericItem : ANamedItem
    {
        public override string Header => "Type parameters";

        public GenericItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
