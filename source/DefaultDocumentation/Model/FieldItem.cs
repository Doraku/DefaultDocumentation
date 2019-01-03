using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldItem : AMemberItem
    {
        public const string Id = "F:";

        public override string Header => "Fields";
        public override string Title => "field";

        public FieldItem(AMemberItem parent, XElement element)
            : base(parent, element)
        { }
    }
}
