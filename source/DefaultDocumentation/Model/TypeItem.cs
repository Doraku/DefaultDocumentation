using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class TypeItem : AGenericDocItem, ITitleDocItem
    {
        public const string Id = "T:";

        public string Title => "type";

        public TypeItem(ADocItem parent, XElement item)
            : base(parent, item)
        { }
    }
}
