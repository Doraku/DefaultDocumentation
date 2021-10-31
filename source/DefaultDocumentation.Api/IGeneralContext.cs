using System.Collections.Generic;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation
{
    public interface IGeneralContext : IContext
    {
        Settings Settings { get; }

        IReadOnlyDictionary<string, DocItem> Items { get; }

        IReadOnlyDictionary<string, IElementWriter> Elements { get; }

        IContext GetContext(DocItem item);

        string GetFileName(DocItem item);

        string GetUrl(DocItem item);

        string GetUrl(string id);

        bool HasOwnPage(DocItem item);
    }
}
