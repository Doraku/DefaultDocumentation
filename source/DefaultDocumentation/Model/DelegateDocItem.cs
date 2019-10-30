using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class DelegateDocItem : TypeDocItem
    {
        public DelegateDocItem(ITypeDefinition type, XElement documentation)
            : base(type, documentation)
        { }
    }
}
