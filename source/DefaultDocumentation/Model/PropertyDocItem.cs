using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyDocItem : DocItem, IParameterizedDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public IProperty Property { get; }

        public ParameterDocItem[] Parameters { get; }

        public PropertyDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(parent, property, documentation)
        {
            Property = property;
            Parameters = Property.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle($"{Parent.Name}.{Name}", "Property");

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```C#");
            writer.WriteLine(CodeAmbience.ConvertSymbol(Property));
            writer.WriteLine("```");

            // attributes

            writer.WriteDocItems(Parameters, "#### Parameters");

            if (Property.ReturnType.Kind != TypeKind.Void)
            {
                writer.WriteLine("#### Returns");
                writer.WriteLine(writer.GetTypeLink(this, Property.ReturnType) + "  ");
                writer.Write(this, Documentation.GetValue());
            }

            writer.WriteExceptions(this);

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
