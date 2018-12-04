using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class ExceptionItem : ADocItem
    {
        public string Reference => Summary.GetReferenceName();

        public ExceptionItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
