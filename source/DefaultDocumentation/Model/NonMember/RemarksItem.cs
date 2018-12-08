using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class RemarksItem : ADocItem
    {
        public RemarksItem(ADocItem parent, XElement element)
            : base(parent, element)
        {
        }
    }
}
