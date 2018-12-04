using System.Xml.Linq;
using DefaultApiDocumentation.Helper;

namespace DefaultApiDocumentation.Model
{
    internal sealed class ExceptionItem : ADocItem
    {
        public string Reference => Summary.GetReferenceName();

        public ExceptionItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
