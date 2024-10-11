using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Types;

/// <summary>
/// Represents a <see cref="ITypeDefinition"/> documentation.
/// </summary>
public abstract class TypeDocItem : EntityDocItem, ITypeParameterizedDocItem
{
    /// <summary>
    /// Gets the <see cref="ITypeDefinition"/> of the current instance.
    /// </summary>
    public ITypeDefinition Type { get; }

    /// <inheritdoc/>
    public IEnumerable<TypeParameterDocItem> TypeParameters { get; }

    private protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement? documentation)
        : base(
              parent is NamespaceDocItem or TypeDocItem ? parent : throw new ArgumentException($"must be either {nameof(NamespaceDocItem)} or {nameof(TypeDocItem)}", nameof(parent)),
              type.ThrowIfNull(),
              documentation)
    {
        Type = type;
        TypeParameters = Type.TypeParameters.Select(typeParameter => new TypeParameterDocItem(this, typeParameter)).ToArray();
    }
}
