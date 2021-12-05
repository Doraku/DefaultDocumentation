using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    /// <summary>
    /// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Enum"/> kind documentation.
    /// </summary>
    public sealed class EnumDocItem : TypeDocItem
    {
        internal EnumDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
            : base(parent, type, documentation)
        { }
    }
}
