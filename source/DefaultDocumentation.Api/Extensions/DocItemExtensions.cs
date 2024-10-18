using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Models;

/// <summary>
/// Provides extension methods on the <see cref="DocItem"/> type.
/// </summary>
public static class DocItemExtensions
{
    /// <summary>
    /// Searchs recursively on the given <see cref="DocItem"/> parent a <see cref="TypeParameterDocItem"/> with the provided name.
    /// </summary>
    /// <param name="item">The <see cref="DocItem"/> starting point from which to look for a specific <see cref="TypeParameterDocItem"/>.</param>
    /// <param name="name">The name of the <see cref="TypeParameterDocItem"/>.</param>
    /// <param name="typeParameterDocItem">The <see cref="TypeParameterDocItem"/> if found, else <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the <see cref="TypeParameterDocItem"/> was found, else <see langword="false"/>.</returns>
    public static bool TryGetTypeParameterDocItem(this DocItem item, string name, [NotNullWhen(true)] out TypeParameterDocItem? typeParameterDocItem)
    {
        item.ThrowIfNull();
        name.ThrowIfNull();

        DocItem? currentItem = item;
        typeParameterDocItem = null;

        while (currentItem != null && typeParameterDocItem == null)
        {
            if (currentItem is ITypeParameterizedDocItem typeParameters)
            {
                typeParameterDocItem = typeParameters.TypeParameters.FirstOrDefault(typeParameter => typeParameter.TypeParameter.Name == name);
            }

            currentItem = currentItem.Parent;
        }

        return typeParameterDocItem != null;
    }

    /// <summary>
    /// Searchs recursively on the given <see cref="DocItem"/> parent a <see cref="ParameterDocItem"/> with the provided name.
    /// </summary>
    /// <param name="item">The <see cref="DocItem"/> starting point from which to look for a specific <see cref="ParameterDocItem"/>.</param>
    /// <param name="name">The name of the <see cref="ParameterDocItem"/>.</param>
    /// <param name="parameterDocItem">The <see cref="ParameterDocItem"/> if found, else <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the <see cref="ParameterDocItem"/> was found, else <see langword="false"/>.</returns>
    public static bool TryGetParameterDocItem(this DocItem item, string name, [NotNullWhen(true)] out ParameterDocItem? parameterDocItem)
    {
        item.ThrowIfNull();
        name.ThrowIfNull();

        DocItem? currentItem = item;
        parameterDocItem = null;

        while (currentItem != null && parameterDocItem == null)
        {
            if (currentItem is IParameterizedDocItem typeParameters)
            {
                parameterDocItem = typeParameters.Parameters.FirstOrDefault(parameter => parameter.Parameter.Name == name);
            }

            currentItem = currentItem.Parent;
        }

        return parameterDocItem != null;
    }

    /// <summary>
    /// Returns all the parents of the given <see cref="DocItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="DocItem"/> for which parents should be returned.</param>
    /// <returns>The parents of the given <see cref="DocItem"/> from the top parent.</returns>
    public static IEnumerable<DocItem> GetParents(this DocItem item)
    {
        item.ThrowIfNull();

        Stack<DocItem> parents = new();
        for (DocItem? parent = item?.Parent; parent != null; parent = parent.Parent)
        {
            parents.Push(parent);
        }

        return parents;
    }
}
