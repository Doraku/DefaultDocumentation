using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    /// <summary>
    /// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Struct"/> kind documentation.
    /// </summary>
    public sealed class StructDocItem : TypeDocItem
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="StructDocItem"/> type.
        /// </summary>
        /// <param name="parent">The <see cref="DocItem"/> parent type or namespace of the class.</param>
        /// <param name="type">The <see cref="ITypeDefinition"/> of the struct.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the struct.</param>
        public StructDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
            : base(parent, type, documentation)
        { }
    }
}
