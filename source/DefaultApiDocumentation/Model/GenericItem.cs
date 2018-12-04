using System.Xml.Linq;

namespace DefaultApiDocumentation.Model
{
    internal sealed class GenericItem : ADocItem
    {
        public GenericItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
