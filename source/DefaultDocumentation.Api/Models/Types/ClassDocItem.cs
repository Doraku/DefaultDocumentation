using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    public sealed class ClassDocItem : TypeDocItem
    {
        public ClassDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
