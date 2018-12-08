using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ExceptionItem : ADocItem
    {
        public string Reference => Summary.GetReferenceName();

        public ExceptionItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
