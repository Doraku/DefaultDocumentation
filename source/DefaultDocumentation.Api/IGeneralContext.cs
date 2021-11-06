using System.Collections.Generic;
using DefaultDocumentation.Models;
using DefaultDocumentation.Api;

namespace DefaultDocumentation
{
    public interface IGeneralContext : IContext
    {
        Settings Settings { get; }

        IReadOnlyDictionary<string, DocItem> Items { get; }

        IReadOnlyDictionary<string, IElement> Elements { get; }

        IContext GetContext(DocItem item);

        string GetFileName(DocItem item);

        string GetUrl(DocItem item);

        string GetUrl(string id);
    }
}
