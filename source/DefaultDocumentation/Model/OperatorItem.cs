using System.Collections.Generic;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model
{
    internal sealed class OperatorItem : AGenericDocItem, IParameterDocItem, IReturnDocItem
    {
        private static readonly HashSet<string> _operatorNames = new HashSet<string>
        {
            "op_Equality",
            "op_Inequality",
            "op_Addition",
            "op_Subtraction",
            "op_Multiply",
            "op_Division",
            "op_BitwiseOr",
            "op_BitwiseAnd",
            "op_OnesComplement",
            "op_ExclusiveOr",
            "op_Increment",
            "op_Decrement",
            "op_LessThan",
            "op_GreaterThan",
            "op_LessThanOrEqual",
            "op_GreaterThanOrEqual",
            "op_UnaryNegation",
            "op_UnaryPlus",
            "op_Modulus",

            "op_Explicit",
            "op_Implicit"
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
            if (_operatorNames.Contains(methodName))
            {
                if (methodName == "op_Explicit"
                    || methodName == "op_Implicit")
                {
                    string[] names = item.Name.Split('~');
                    return new OperatorItem(item, $"{methodName.Substring(3)}{names[0].Substring(methodName.Length).TrimEnd(')')} to {names[1]})");
                }

                return new OperatorItem(item, $"{methodName.Substring(3)}{item.Name.Substring(methodName.Length)}");
            }

            return item;
        }
    }
}
