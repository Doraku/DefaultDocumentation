using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class OperatorItem : AMemberItem, IParameterDocItem, IReturnDocItem
    {
        private static readonly Dictionary<string, string> _operatorNames = new Dictionary<string, string>
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
            ["op_Increment"] = "++",
            ["op_Decrement"] = "--",
            ["op_LessThan"] = "<",
            ["op_GreaterThan"] = ">",
            ["op_LessThanOrEqual"] = "<=",
            ["op_GreaterThanOrEqual"] = ">=",
            ["op_Modulus"] = "%",
            ["op_UnaryNegation"] = "-",
            ["op_UnaryPlus"] = "+",
            ["op_LeftShift"] = "<<",
            ["op_RightShift"] = ">>",

            ["op_Explicit"] = "explicit",
            ["op_Implicit"] = "implicit"
        };

        private readonly bool _isImplExpl;

        public override string Header => "Operators";
        public override string Title => "operator";

        public MethodDefinition Method { get; }

        public ReturnItem Return { get; }

        public ParameterItem[] Parameters { get; }

        private OperatorItem(MethodItem innerItem, string name, MethodDefinition method, bool isImplExpl = false)
            : base(innerItem.Parent, name, innerItem.Element)
        {
            Return = innerItem.Return;
            Parameters = innerItem.Parameters;
            Method = method;
            _isImplExpl = isImplExpl;
        }

        public static AMemberItem HandleOperator(MethodItem item)
        {
            string methodName = item.Name.Substring(0, item.Name.IndexOf('('));
            if (_operatorNames.ContainsKey(methodName))
            {
                if (methodName == "op_Explicit"
                    || methodName == "op_Implicit")
                {
                    string[] names = item.Name.Split('~');
                    return new OperatorItem(item, $"{methodName.Substring(3)}{names[0].Substring(methodName.Length).TrimEnd(')')} to {names[1]})", item.Method, true);
                }

                return new OperatorItem(item, $"{methodName.Substring(3)}{item.Name.Substring(methodName.Length)}", item.Method);
            }

            return item;
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Method.IsStatic)
            {
                writer.Write("static ");
            }
            writer.Write(Return.IsVoid ? "void" : Return.Type.FullName);
            if (_isImplExpl)
            {
                writer.Write($" {_operatorNames[Method.Name]} operator ");
            }
            else
            {
                writer.Write($" operator {_operatorNames[Method.Name]}");
            }
            writer.WriteLine($"({string.Join(", ", Parameters.Select(p => p.Signature))});");
            writer.WriteLine("```");

            if (Parameters.Length > 0)
            {
                writer.WriteLine($"### {Parameters[0].Header}");

                foreach (ParameterItem parameter in Parameters)
                {
                    parameter.Write(converter, writer);
                    writer.Break();
                }
            }

            Return.Write(converter, writer);

            base.Write(converter, writer);
        }
    }
}
