using System.Linq;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorItem : AMemberItem, IParameterDocItem
    {
        public const string Id = "M:";

        public override string Header => "Constructors";
        public override string Title => "constructor";

        public MethodDefinition Constructor { get; }

        public ParameterItem[] Parameters { get; }

        public ConstructorItem(MethodItem innerItem)
            : base(innerItem.Parent, innerItem.Name, innerItem.Element)
        {
            Constructor = innerItem.Method;
            Parameters = innerItem.Parameters;
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Constructor.IsStatic)
            {
                writer.Write("static ");
            }
            writer.WriteLine($"{Parent.Name}({string.Join(", ", Parameters.Select(p => p.Signature))});");
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

            base.Write(converter, writer);
        }
    }
}
