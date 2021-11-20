using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    public sealed class StructDocItem : TypeDocItem
    {
        public StructDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
