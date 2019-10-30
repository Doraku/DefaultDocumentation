using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class StructDocItem : TypeDocItem
    {
        public StructDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        { }
    }
}
