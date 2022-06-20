using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.PluginExample
{
    public sealed class FolderFileNameOverrides : ISection
    {
        private void AppendLink(IWriter writer, DocItem item, string displayedName)
        {
            if (item is ExternDocItem)
            {
                writer.AppendUrl(writer.Context.GetUrl(item), displayedName ?? item.Name, item.FullName);
            }
            else
            {
                string[] url = writer.Context.GetUrl(item).Split('/');
                string[] pageUrl = writer.Context.GetUrl(writer.DocItem).Split('/');

                List<string> relativeUrl = new();

                int pathCount;
                for (pathCount = 0; pathCount < pageUrl.Length && pathCount < url.Length && pageUrl[pathCount] == url[pathCount]; pathCount++)
                { }

                relativeUrl.AddRange(Enumerable.Repeat("..", Math.Max(0, pageUrl.Length - pathCount - 1)));
                relativeUrl.AddRange(url.Skip(pathCount));

                writer.AppendUrl(string.Join("/", relativeUrl), displayedName ?? item.Name, item.FullName);
            }
        }

        public string Name => nameof(FolderFileNameOverrides);

        public void Write(IWriter writer)
        {
            writer.SetAppendLinkOverride(AppendLink);
        }
    }
}
