using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation;

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
    /// Gets the <see cref="IUrlFactory"/> used to create the documentation urls.
    /// </summary>
    IEnumerable<IUrlFactory> UrlFactories { get; }

    /// <summary>
    /// Gets the specific <see cref="IContext"/> for the given <see cref="Type"/>.
    /// </summary>
    /// <param name="type">The <see cref="Type"/> for which to get the specific <see cref="IContext"/>.</param>
    /// <returns>The <see cref="IContext"/> specific to the provided <see cref="Type"/>.</returns>
    IContext GetContext(Type? type);

    /// <summary>
    /// Gets the file name for the given <see cref="DocItem"/>.
    /// </summary>
    /// <param name="item">The <see cref="DocItem"/> for which to get the page name.</param>
    /// <returns>The file name of the documentation page of the given <see cref="DocItem"/>.</returns>
    string GetFileName(DocItem item);
}
