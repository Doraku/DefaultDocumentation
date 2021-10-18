using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    public sealed class InterfaceDocItem : TypeDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Interfaces;

        public InterfaceDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
