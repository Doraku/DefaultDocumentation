using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model.NonMember
{
    internal sealed class GenericItem : ANamedItem
    {
        public override string Header => "Type parameters";

        private GenericItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }

        public static GenericItem[] GetFrom(AMemberItem item)
        {
            return item.Element.GetGenerics().Select(i => new GenericItem(item, i)).ToArray();
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine(this.AsLinkTarget());
            writer.WriteLine($"`{Name}`  ");
            converter.WriteSummary(writer, this);
        }
    }
}
