using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ConstructorDocItem : DocItem, IParameterizedDocItem
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
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public IMethod Method { get; }
        public ParameterDocItem[] Parameters { get; }

        public ConstructorDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, "Constructor");

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```csharp");
            writer.WriteLine(CodeAmbience.ConvertSymbol(Method));
            writer.WriteLine("```");

            // attributes

            writer.WriteDocItems(Parameters, "#### Parameters");

            writer.WriteExceptions(this);

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);
        }
    }
}
