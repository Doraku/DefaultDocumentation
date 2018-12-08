using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ParameterItem : ADocItem
    {
        public ParameterItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
