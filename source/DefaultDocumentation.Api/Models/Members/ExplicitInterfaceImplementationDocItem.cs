using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    public sealed class ExplicitInterfaceImplementationDocItem : EntityDocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        public IMember Member { get; }

        public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  @event ?? throw new ArgumentNullException(nameof(@event)),
                  documentation)
        {
            Member = @event;
            TypeParameters = Array.Empty<TypeParameterDocItem>();
            Parameters = Array.Empty<ParameterDocItem>();
        }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  property ?? throw new ArgumentNullException(nameof(property)),
                  documentation)
        {
            Member = property;
            TypeParameters = Array.Empty<TypeParameterDocItem>();
            Parameters = property.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }

        public ExplicitInterfaceImplementationDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  method ?? throw new ArgumentNullException(nameof(method)),
                  documentation)
        {
            Member = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }
    }
}
