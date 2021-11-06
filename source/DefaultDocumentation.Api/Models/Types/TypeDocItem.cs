using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    public abstract class TypeDocItem : EntityDocItem, ITypeParameterizedDocItem
    {
        public ITypeDefinition Type { get; }

        public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

        private protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(
                  parent is NamespaceDocItem or TypeDocItem ? parent : throw new ArgumentException($"must be either {nameof(NamespaceDocItem)} or {nameof(TypeDocItem)}", nameof(parent)),
                  type ?? throw new ArgumentNullException(nameof(type)),
                  documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p)).ToArray();
        }
    }
}
