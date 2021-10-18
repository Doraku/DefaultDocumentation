using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class MethodDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem, IDefinedDocItem
    {
        public static readonly CSharpAmbience CodeAmbience = new()
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

        public override GeneratedPages Page => GeneratedPages.Methods;

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

        public XElement Definition => new("code", $"{CodeAmbience.ConvertSymbol(Method)}{this.GetConstraints()};");
    }
}
