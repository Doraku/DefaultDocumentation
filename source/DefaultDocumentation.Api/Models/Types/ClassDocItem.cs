using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types;

/// <summary>
/// Represents a <see cref="ITypeDefinition"/> of the <see cref="TypeKind.Class"/> kind documentation.
/// </summary>
public sealed class ClassDocItem : TypeDocItem
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ClassDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="DocItem"/> parent type or namespace of the class.</param>
    /// <param name="type">The <see cref="ITypeDefinition"/> of the class.</param>
    /// <param name="documentation">The <see cref="XElement"/> documentation element of the class.</param>
    public ClassDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
        : base(parent, type, documentation)
    { }
}
