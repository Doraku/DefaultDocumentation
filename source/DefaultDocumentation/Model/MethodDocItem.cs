using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class MethodDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public IMethod Method { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        public ParameterDocItem[] Parameters { get; }

        public MethodDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle($"{Parent.Name}.{Name}", "Method");

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```csharp");
            writer.Write(CodeAmbience.ConvertSymbol(Method));
            writer.WriteConstraints(TypeParameters);
            writer.WriteLine(";");
            writer.WriteLine("```");

            // attributes

            writer.WriteDocItems(TypeParameters, "#### Type parameters");
            writer.WriteDocItems(Parameters, "#### Parameters");

            if (Method.ReturnType.Kind != TypeKind.Void)
            {
                writer.WriteLine("#### Returns");
                writer.WriteLine(writer.GetTypeLink(Method.ReturnType) + "  ");
                writer.Write(this, Documentation.GetReturns());
            }

            writer.WriteExceptions(this);

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
