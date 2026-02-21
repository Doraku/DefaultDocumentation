using System;
using System.Linq;
using DefaultDocumentation.Models;

namespace DefaultDocumentation;

/// <summary>
/// Provides extension methods on the <see cref="IPageContext"/> type.
/// </summary>
public static class IPageContextExtensions
{
    /// <summary>
    /// Gets the url of the given <see cref="DocItem"/> in a specific page.
    /// </summary>
    /// <param name="context">The <see cref="IPageContext"/> of the current documentation file.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to get the url.</param>
    /// <returns>The url of the given <see cref="DocItem"/>.</returns>
    public static string? GetUrl(this IPageContext context, DocItem item)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(item);

        return context.GetUrl(item.Id);
    }

    /// <summary>
    /// Gets the url of the given id in a specific page.
    /// </summary>
    /// <param name="context">The <see cref="IPageContext"/> of the current documentation file.</param>
    /// <param name="id">The id for which to get the url.</param>
    /// <returns>The url of the given <see cref="DocItem"/>.</returns>
    public static string? GetUrl(this IPageContext context, string id)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(id);

        return context.UrlFactories.Select(urlFactory => urlFactory.GetUrl(context, id)).FirstOrDefault(url => url is not null);
    }
}
