using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class EnumDocItem : TypeDocItem
    {
        public EnumDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        { }
    }
}
