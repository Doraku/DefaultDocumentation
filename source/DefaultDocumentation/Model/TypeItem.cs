using System.Xml.Linq;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class TypeItem : AGenericDocItem
    {
        public const string Id = "T:";

        public override string Header => "Types";
        public override string Title => "type";

        public TypeItem(AMemberItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
