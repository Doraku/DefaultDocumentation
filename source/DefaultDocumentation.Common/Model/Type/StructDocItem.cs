using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    internal sealed class StructDocItem : TypeDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Structs;

        public StructDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
