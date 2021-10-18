using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class ConstructorDocItem : DocItem, IParameterizedDocItem, IDefinedDocItem
    {
        public static readonly CSharpAmbience CodeAmbience = new()
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

        public override GeneratedPages Page => GeneratedPages.Constructors;

        public IMethod Method { get; }

        public ParameterDocItem[] Parameters { get; }

        public ConstructorDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Method = method;
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public XElement Definition => new("code", CodeAmbience.ConvertSymbol(Method));
    }
}
