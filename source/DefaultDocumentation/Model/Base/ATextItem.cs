using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class ATextItem
    {
        public ADocItem Parent { get; }
        public XElement Element { get; }
        public XElement Summary => Element.GetSummary() ?? Element;

        protected ATextItem(ADocItem parent, XElement element)
        {
            Element = element;
            Parent = parent;
        }
    }
}
