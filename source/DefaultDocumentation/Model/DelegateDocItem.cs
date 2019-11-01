using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class DelegateDocItem : TypeDocItem, IParameterizedDocItem
    {
        public IMethod InvokeMethod { get; }

        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public ParameterDocItem[] Parameters { get; }

        public DelegateDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            InvokeMethod = type.GetDelegateInvokeMethod();
            Parameters = InvokeMethod.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, Type.Kind.ToString());

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```C#");
            writer.WriteLine(CodeAmbience.ConvertSymbol(Type));
            writer.WriteLine("```");

            // attribute

            writer.WriteDocItems(TypeParameters, "#### Type parameters");
            writer.WriteDocItems(Parameters, "#### Parameters");

            if (InvokeMethod.ReturnType.Kind != TypeKind.Void)
            {
                writer.WriteLine("#### Returns");
                writer.WriteLine(writer.GetTypeLink(this, InvokeMethod.ReturnType) + "  ");
                writer.Write(this, Documentation.GetReturns());
            }

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
