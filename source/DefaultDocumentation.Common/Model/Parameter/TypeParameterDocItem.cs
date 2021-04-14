using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Parameter
{
    internal sealed class TypeParameterDocItem : DocItem
    {
        public ITypeParameter TypeParameter { get; }

        public TypeParameterDocItem(DocItem parent, ITypeParameter entity, XElement documentation)
            : base(parent, $"{parent.Id}>{entity.Name}", $"{parent.FullName}.{entity.Name}", entity.Name, documentation.GetTypeParameters()?.FirstOrDefault(d => d.GetNameAttribute() == entity.Name))
        {
            TypeParameter = entity;
        }
    }
}
