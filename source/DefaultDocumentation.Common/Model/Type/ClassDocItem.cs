using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    internal sealed class ClassDocItem : TypeDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Classes;

        public ClassDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        { }
    }
}
