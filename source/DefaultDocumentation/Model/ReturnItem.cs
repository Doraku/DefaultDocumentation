using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class ReturnItem : ADocItem
    {
        public ReturnItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
