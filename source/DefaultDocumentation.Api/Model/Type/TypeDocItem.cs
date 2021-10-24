using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    public abstract class TypeDocItem : DocItem, ITypeParameterizedDocItem
    {
        public ITypeDefinition Type { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
        }
    }
}
