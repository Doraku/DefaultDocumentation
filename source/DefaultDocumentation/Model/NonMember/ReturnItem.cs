using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ReturnItem : ATextItem, ITitleDocItem
    {
        public string Title => "Returns";

        public ReturnItem(ADocItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
