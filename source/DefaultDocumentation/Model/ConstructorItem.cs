using System.Xml.Linq;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorItem : AGenericDocItem, ITitleDocItem, IParameterDocItem
    {
        public const string Id = "M:";

        public string Title => "constructor";

        public ParameterItem[] Parameters { get; }

        public ConstructorItem(MethodItem innerItem)
            : base(innerItem.Parent, innerItem.Name, innerItem.Element)
        {
            Parameters = innerItem.Parameters;
        }
    }
}
