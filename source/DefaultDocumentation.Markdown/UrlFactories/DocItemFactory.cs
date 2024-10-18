using System;
using System.IO;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Markdown.Models;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;

namespace DefaultDocumentation.Markdown.UrlFactories;

/// <summary>
/// Handles id for known <see cref="DocItem"/>.
/// </summary>
public sealed class DocItemFactory : IUrlFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "DocItem";

    /// <inheritdoc/>
    public string Name => ConfigName;

    /// <inheritdoc/>
    public string? GetUrl(IPageContext context, string id)
    {
        context.ThrowIfNull();
        id.ThrowIfNull();

        if (!context.Items.TryGetValue(id, out DocItem item))
        {
            return null;
        }

        DocItem pagedItem;

        switch (item)
        {
            case ExternDocItem externItem:
                return externItem.Url;

            case ConstructorDocItem constructorItem:
                pagedItem = context.GetChildren<ConstructorOverloadsDocItem>(constructorItem.Parent!).SingleOrDefault() ?? item;
                break;

            case MethodDocItem methodItem:
                pagedItem = context.GetChildren<MethodOverloadsDocItem>(methodItem.Parent!).SingleOrDefault(overloadItem => overloadItem.Name == methodItem.Method.Name) ?? item;
                break;

            default:
                pagedItem = item;
                break;
        }

        while (!context.ItemsWithOwnPage.Contains(pagedItem))
        {
            if (pagedItem.Parent is null)
            {
                return null;
            }

            pagedItem = pagedItem.Parent;
        }

        string url = context.GetFileName(pagedItem);

        if (context.GetUseFullUrl() && !string.IsNullOrWhiteSpace(context.Settings.LinksBaseUrl))
        {
            url = context.Settings.LinksBaseUrl!.Trim('/') + '/' + url;
        }

        if (context.GetRemoveFileExtensionFromUrl() && Path.HasExtension(url))
        {
            url = url[..^Path.GetExtension(url).Length];
        }

        if (item != pagedItem)
        {
            url += "#" + PathCleaner.Clean(item.FullName, context.GetInvalidCharReplacement());
        }

        return url;
    }
}
