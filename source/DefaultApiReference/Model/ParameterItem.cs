using System.Xml.Linq;

namespace DefaultApiReference.Model
{
    internal sealed class ParameterItem : ADocItem
    {
        public ParameterItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
