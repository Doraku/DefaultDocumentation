using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class ExampleItem : AItem
    {
        public override string Header => "Example";

        private ExampleItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }

        public static ExampleItem GetFrom(AMemberItem item)
        {
            XElement exampleElement = item.Element.GetExample();
            return exampleElement != null ? new ExampleItem(item, exampleElement) : null;
        }
    }
}
