using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorItem : AGenericDocItem, ITitleDocItem, IParameterDocItem
    {
        public const string Id = "M:";

        public string Title => "constructor";

        public ParameterItem[] Parameters { get; }

        public ConstructorItem(MethodItem innerItem, XElement item)
            : base(innerItem.Parent, innerItem.Name, item)
        {
            Parameters = innerItem.Parameters;
        }
    }
}
