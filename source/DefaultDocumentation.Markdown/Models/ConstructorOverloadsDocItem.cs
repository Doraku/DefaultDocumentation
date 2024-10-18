using System;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Models;

/// <summary>
/// Represents the different overload of the constructors of a given <see cref="TypeDocItem"/>.
/// </summary>
public sealed class ConstructorOverloadsDocItem : DocItem
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ConstructorOverloadsDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent.</param>
    public ConstructorOverloadsDocItem(TypeDocItem parent)
        : base(parent.ThrowIfNull(), $"M{parent.Id[1..]}.{parent.Name}", $"{parent.FullName}.#ctor", parent.Name, null)
    { }
}
