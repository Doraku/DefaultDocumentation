using System;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Types;

namespace DefaultDocumentation.Markdown.Models;

/// <summary>
/// Represents the different overload of a method of a given <see cref="TypeDocItem"/>.
/// </summary>
public sealed class MethodOverloadsDocItem : DocItem
{
    /// <summary>
    /// Initialize a new instance of the <see cref="MethodOverloadsDocItem"/> type.
    /// </summary>
    /// <param name="parent">The <see cref="TypeDocItem"/> parent.</param>
    /// <param name="methodName">The method name of the overloads.</param>
    public MethodOverloadsDocItem(TypeDocItem parent, string methodName)
        : base(
            parent ?? throw new ArgumentNullException(nameof(parent)),
            $"?{parent.Id[1..]}.{methodName ?? throw new ArgumentNullException(nameof(methodName))}",
            $"{parent.FullName}.{methodName}",
            methodName,
            null)
    { }
}
