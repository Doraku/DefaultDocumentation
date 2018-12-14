using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ExampleItem : ADocItem, ITitleDocItem
    {
        public string Title => "Example";

        public ExampleItem(ADocItem parent, XElement element)
            : base(parent, element)
        {
        }
    }
}
