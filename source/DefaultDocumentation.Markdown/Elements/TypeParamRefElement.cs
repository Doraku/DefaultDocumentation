using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Markdown.Elements;

/// <summary>
/// Handles <c>typeparamref</c> xml element.
/// </summary>
public sealed class TypeParamRefElement : IElement
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "typeparamref";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer, XElement element)
    {
        writer.ThrowIfNull();
        element.ThrowIfNull();

        string? name = element.GetNameAttribute();

        if (name != null)
        {
            _ = writer.GetCurrentItem().TryGetTypeParameterDocItem(name, out TypeParameterDocItem? typeParameter) ? writer.AppendLink(typeParameter) : writer.Append(name);
        }
    }
}
