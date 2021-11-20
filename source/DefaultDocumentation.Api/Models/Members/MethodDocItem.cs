using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    public sealed class MethodDocItem : EntityDocItem, ITypeParameterizedDocItem, IParameterizedDocItem
    {
        public IMethod Method { get; }

        public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public MethodDocItem(TypeDocItem parent, IMethod method, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  method ?? throw new ArgumentNullException(nameof(method)),
                  documentation)
        {
            Method = method;
            TypeParameters = method.TypeParameters.Select(p => new TypeParameterDocItem(this, p)).ToArray();
            Parameters = method.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }
    }
}
