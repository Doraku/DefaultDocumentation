using System.Xml.Linq;

namespace DefaultApiDocumentation.Model
{
    internal sealed class ParameterItem : ADocItem
    {
        public ParameterItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
