using System.Xml.Linq;

namespace DefaultApiDocumentation.Model
{
    internal sealed class TypeItem : AGenericDocItem, ITitleDocItem
    {
        public const string Id = "T:";

        public string Title => "type";

        public TypeItem(XElement item)
            : base(item.GetNamespace(), item)
        { }
    }
}
