using System.Collections.Generic;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class OperatorItem : AGenericDocItem, IParameterDocItem, IReturnDocItem
    {
        public static readonly IReadOnlyDictionary<string, string> OperatorNames = new Dictionary<string, string>
        {
            ["op_Equality"] = "==",
            ["op_Inequality"] = "!=",
            ["op_Addition"] = "+",
            ["op_Subtraction"] = "-",
            ["op_Multiply"] = "*",
            ["op_Division"] = "/",
            ["op_BitwiseOr"] = "|",
            ["op_BitwiseAnd"] = "&",
            ["op_OnesComplement"] = "~",
            ["op_ExclusiveOr"] = "^",
        };

        public override string Header => "Operators";
        public override string Title => "operator";

        public ReturnItem Return { get; }

        public ParameterItem[] Parameters { get; }

        private OperatorItem(MethodItem innerItem, string name)
            : base(innerItem.Parent, name, innerItem.Element)
        {
            Return = innerItem.Return;
            Parameters = innerItem.Parameters;
        }

        public static AMemberItem HandleOperator(MethodItem item)
        {
            string methodName = item.Name.Substring(0, item.Name.IndexOf('('));
            if (OperatorNames.TryGetValue(methodName, out string op))
            {
                return new OperatorItem(item, $"{op}{item.Name.Substring(methodName.Length)}");
            }

            return item;
        }
    }
}
