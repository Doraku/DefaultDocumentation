using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ParameterItem : ANamedItem
    {
        public override string Header => "Parameters";

        public ParameterItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
