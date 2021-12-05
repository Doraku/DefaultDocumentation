using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation
{
    /// <summary>
    /// Exposes settings used to generate documentation.
    /// </summary>
    public interface IGeneralContext : IContext
    {
        /// <summary>
        /// Gets the <see cref="ISettings"/> of this documentation generation context.
        /// </summary>
        ISettings Settings { get; }

        /// <summary>
        /// Gets all the <see cref="DocItem"/> known by this documentation generation context.
        /// </summary>
        IReadOnlyDictionary<string, DocItem> Items { get; }

        /// <summary>
        /// Gets the <see cref="IElement"/> used to render specific <see cref="System.Xml.Linq.XElement"/> from the documentation.
        /// </summary>
        IReadOnlyDictionary<string, IElement> Elements { get; }

        /// <summary>
        /// Gets the specific <see cref="IContext"/> for the given <see cref="DocItem"/> kind.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IContext? GetContext(DocItem item);

        /// <summary>
        /// Gets the file name for the given <see cref="DocItem"/>.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> for which to get the page name.</param>
        /// <returns>The file name of the documentation page of the given <see cref="DocItem"/>.</returns>
        string GetFileName(DocItem item);

        /// <summary>
        /// Gets the url of the given <see cref="DocItem"/>.
        /// For <see cref="DocItem"/> which have their own page, this is their file name.
        /// For <see cref="DocItem"/> which do not have their own page, it is their nearest parent when it own page file name with a target tag of its id.
        /// </summary>
        /// <param name="item">The <see cref="DocItem"/> for which to get the url.</param>
        /// <returns>The url of the given <see cref="DocItem"/>.</returns>
        string GetUrl(DocItem item);

        /// <summary>
        /// Gets thr url of the given id.
        /// If this id is known in the <see cref="Items"/> of this context, it will return its url, otherwise, a dotnet api link will be generated.
        /// </summary>
        /// <param name="id">The id to get the url for.</param>
        /// <returns>The url of the given id.</returns>
        string GetUrl(string id);
    }
}
