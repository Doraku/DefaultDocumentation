using System.Xml.Linq;

namespace DefaultApiReference.Model
{
    internal sealed class ExceptionItem : ADocItem
    {
        public string Reference => Summary.GetReferenceName();

        public ExceptionItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
