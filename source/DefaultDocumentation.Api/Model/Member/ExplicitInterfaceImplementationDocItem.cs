using System;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class ExplicitInterfaceImplementationDocItem : DocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.ExplicitInterfaceImplementations;

        public IMember Member { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        public ParameterDocItem[] Parameters { get; }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(parent, @event, documentation)
        {
            Member = @event;
            TypeParameters = Array.Empty<TypeParameterDocItem>();
            Parameters = Array.Empty<ParameterDocItem>();
        }

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
    }
}
