using System;
using System.Linq;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories;

/// <summary>
/// <see cref="Api.IFileNameFactory"/> implementation using <see cref="DocItem.Name"/> and an md5 on the <see cref="DocItem.FullName"/> as file name.
/// </summary>
public sealed class NameAndMd5MixFactory : BaseMarkdownFileNameFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "NameAndMd5Mix";

    /// <inheritdoc/>
    public override string Name => ConfigName;

    /// <inheritdoc/>
    protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(item);

        return item is EntityDocItem entity && item is IParameterizedDocItem parameterized && parameterized.Parameters.Any()
            ? $"{item.Parent!.GetLongName()}.{entity.Entity.Name}.{Md5Factory.GetMd5HashBase36(item.FullName)}"
            : item.GetLongName();
    }
}
