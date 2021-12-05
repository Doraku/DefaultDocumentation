using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    /// <summary>
    /// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Struct"/> kind documentation.
    /// </summary>
    public sealed class StructDocItem : TypeDocItem
    {
        internal StructDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
            : base(parent, type, documentation)
        { }
    }
}
