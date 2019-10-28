using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using DefaultDocumentation.Model.NonMember;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyItem : AMemberItem
    {
        public const string Id = "P:";

        public override string Header => "Properties";
        public override string Title => "property";

        public PropertyDefinition Property { get; }

        public ParameterItem[] Parameters { get; }

        public ValueItem Value { get; }

        public PropertyItem(AMemberItem parent, XElement element)
            : base(parent, GetPropertyName(element, parent), element)
        {
            TypeDefinition parentType = (parent as TypeItem).Type;

            Property = parentType.Properties.First(p => p.Name == Name);

            Parameters = element.GetParameters().Select(e => new ParameterItem(this, e)).ToArray();
            Value = new ValueItem(this, element.GetValue() ?? new XElement("value"));
        }

        private static string GetPropertyName(XElement element, AMemberItem parent)
        {
            string name = element.GetName();

            if (name.EndsWith(")"))
            {
                name = MethodItem.GetMethodName(element, parent);
                name = $"this[{name.Substring(name.IndexOf('(') + 1).Replace(')', ']')}";
            }

            return name;
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Property.SetMethod?.IsStatic ?? Property.GetMethod?.IsStatic ?? false)
            {
                writer.Write("static ");
            }
            if (Parameters.Length > 0)
            {
                writer.Write($"this[{string.Join(", ", Parameters.Select(p => p.Signature))}] {{");
            }
            else
            {
                writer.Write($"{Value.Type.FullName} {{ ");
            }
            if (Property.GetMethod != null)
            {
                writer.Write(" get;");
            }
            if (Property.SetMethod != null)
            {
                writer.Write(" set;");
            }
            writer.WriteLine("}}");
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

            Value.Write(converter, writer);

            base.Write(converter, writer);
        }
    }
}
