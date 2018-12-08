using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class GenericItem : ADocItem
    {
        public GenericItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
