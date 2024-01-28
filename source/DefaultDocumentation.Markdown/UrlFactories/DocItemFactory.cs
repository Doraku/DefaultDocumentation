using System.IO;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.UrlFactories
{
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
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(id);

            if (!context.Items.TryGetValue(id, out DocItem item))
            {
                return null;
            }

            if (item is ExternDocItem externItem)
            {
                return externItem.Url;
            }

            DocItem pagedItem = item;
            while (!pagedItem.HasOwnPage(context))
            {
                pagedItem = pagedItem.Parent!;
            }

            string url = context.GetFileName(pagedItem);

            if (context.GetUseFullUrl() && !string.IsNullOrWhiteSpace(context.Settings.LinksBaseUrl))
            {
                url = context.Settings.LinksBaseUrl!.Trim('/') + '/' + url;
            }

            if (context.GetRemoveFileExtensionFromUrl() && Path.HasExtension(url))
            {
                url = url.Substring(0, url.Length - Path.GetExtension(url).Length);
            }

            if (item != pagedItem)
            {
                url += "#" + PathCleaner.Clean(item.FullName, context.GetInvalidCharReplacement());
            }

            return url;
        }
    }
}
