using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    internal sealed class DelegateDocItem : TypeDocItem, IParameterizedDocItem
    {
        public IMethod InvokeMethod { get; }

        private static readonly CSharpAmbience CodeAmbience = new()
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

        public override void WriteDefinition(StringBuilder builder) => builder.AppendLine(CodeAmbience.ConvertSymbol(Type));
    }
}
