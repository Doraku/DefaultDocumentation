using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class TypeDocItem : DocItem
    {
        public ITypeDefinition Type { get; }

        protected TypeDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        {
            Type = type;
        }
    }
}
