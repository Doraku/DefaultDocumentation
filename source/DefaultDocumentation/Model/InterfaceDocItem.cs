using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class InterfaceDocItem : TypeDocItem
    {
        public InterfaceDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        { }
    }
}
