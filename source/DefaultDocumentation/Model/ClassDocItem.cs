using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ClassDocItem : TypeDocItem
    {
        public ClassDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        { }
    }
}
