using System.IO;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.UrlFactories
{
    public sealed class DocItemFactory : IUrlFactory
    {
        public string Name => "DocItem";

        public string GetUrl(IGeneralContext context, string id)
        {
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
                pagedItem = pagedItem.Parent;
            }

            string url = context.GetFileName(pagedItem);
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
