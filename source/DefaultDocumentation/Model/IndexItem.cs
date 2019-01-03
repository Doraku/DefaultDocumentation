using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class IndexItem : AMemberItem, IParameterDocItem, IReturnDocItem
    {
        public override string Header => "Indexes";
        public override string Title => "index";

        public ReturnItem Return { get; }

        public ParameterItem[] Parameters { get; }

        public IndexItem(MethodItem item)
            : base(item.Parent, ToIndexName(item.Name), item.Element)
        {
            Return = item.Return;
            Parameters = item.Parameters;
        }

        private static string ToIndexName(string name)
        {
            name = name.Substring(name.IndexOf('(') + 1);

            return $"this[{name.Replace(')', ']')}";
        }
    }
}
