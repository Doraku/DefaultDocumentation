using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class ExplicitInterfaceImplementationDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem, IDefinedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.ExplicitInterfaceImplementations;

        public IMember Member { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        public ParameterDocItem[] Parameters { get; }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(parent, property, documentation)
        {
            Member = property;
            TypeParameters = Array.Empty<TypeParameterDocItem>();
            Parameters = property.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(parent, method, documentation)
        {
            Member = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public void WriteDefinition(StringBuilder builder)
        {
            if (Member is IProperty)
            {
                builder.AppendLine(PropertyDocItem.CodeAmbience.ConvertSymbol(Member));
            }
            else if (Member is IMethod)
            {
                builder.Append(MethodDocItem.CodeAmbience.ConvertSymbol(Member));
                builder.Append(this.GetConstraints());
                builder.AppendLine(";");
            }
        }
    }
}
