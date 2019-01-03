using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorItem : AMemberItem, IParameterDocItem
    {
        public const string Id = "M:";

        public override string Header => "Constructors";
        public override string Title => "constructor";

        public ParameterItem[] Parameters { get; }

        public ConstructorItem(MethodItem innerItem)
            : base(innerItem.Parent, innerItem.Name, innerItem.Element)
        {
            Parameters = innerItem.Parameters;
        }
    }
}
