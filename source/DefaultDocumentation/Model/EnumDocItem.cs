using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class EnumDocItem : TypeDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
        };

        public EnumDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, Type.Kind.ToString());

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```csharp");
            writer.Write(CodeAmbience.ConvertSymbol(Type));
            IType enumType = Type.GetEnumUnderlyingType();
            writer.WriteLine(enumType.IsKnownType(KnownTypeCode.Int32) ? string.Empty : $" : {enumType.FullName}");
            writer.WriteLine("```");

            // attribute

            writer.WriteDocItems<EnumFieldDocItem>("### Fields");

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
