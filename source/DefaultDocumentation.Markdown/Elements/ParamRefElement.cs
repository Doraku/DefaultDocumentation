using System;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;

namespace DefaultDocumentation.Markdown.Elements;

/// <summary>
/// Handles <c>paramref</c> xml element.
/// </summary>
public sealed class ParamRefElement : IElement
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "paramref";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public void Write(IWriter writer, XElement element)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(element);

        string? name = element.GetNameAttribute();

        if (name != null)
        {
            _ = writer.GetCurrentItem().TryGetParameterDocItem(name, out ParameterDocItem? parameter) ? writer.AppendLink(parameter) : writer.Append(name);
        }
    }
}
