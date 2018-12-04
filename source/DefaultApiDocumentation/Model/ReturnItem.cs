using System.Xml.Linq;

namespace DefaultApiDocumentation.Model
{
    internal sealed class ReturnItem : ADocItem
    {
        public ReturnItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
