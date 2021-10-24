using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    public sealed class EnumDocItem : TypeDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Enums;

        public EnumDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
