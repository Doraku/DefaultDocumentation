using System;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories;

/// <summary>
/// <see cref="Api.IFileNameFactory"/> implementation using <see cref="DocItem.FullName"/> as file name.
/// </summary>
public sealed class FullNameFactory : BaseMarkdownFileNameFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "FullName";

    /// <inheritdoc/>
    public override string Name => ConfigName;

    /// <inheritdoc/>
    protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(item);

        return item.FullName;
    }
}
