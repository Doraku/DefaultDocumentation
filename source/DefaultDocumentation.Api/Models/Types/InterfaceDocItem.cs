using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types
{
    /// <summary>
    /// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Interface"/> kind documentation.
    /// </summary>
    public sealed class InterfaceDocItem : TypeDocItem
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="StructDocItem"/> type.
        /// </summary>
        /// <param name="parent">The <see cref="DocItem"/> parent type or namespace of the interface.</param>
        /// <param name="type">The <see cref="ITypeDefinition"/> of the interface.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the interface.</param>
        public InterfaceDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
            : base(parent, type, documentation)
        { }
    }
}
