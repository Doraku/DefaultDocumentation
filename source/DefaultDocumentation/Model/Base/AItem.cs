using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class AItem
    {
        public abstract string Header { get; }

        public AMemberItem Parent { get; }
        public XElement Element { get; }
        public XElement Summary { get; }

        protected AItem(AMemberItem parent, XElement element)
        {
            Parent = parent;
            Element = element;
            Summary = Element.GetSummary() ?? Element;
        }
    }
}
