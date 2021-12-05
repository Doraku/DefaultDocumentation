using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    /// <summary>
    /// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Interface"/> kind documentation.
    /// </summary>
    public sealed class InterfaceDocItem : TypeDocItem
    {
        internal InterfaceDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
            : base(parent, type, documentation)
        { }
    }
}
