using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation;

/// <summary>
/// Exposes properties and methods used to impact the <see cref="DocItem"/> that will be generated, used by <see cref="IDocItemGenerator"/>
/// </summary>
public interface IDocItemsContext
{
    /// <summary>
    /// Gets the <see cref="ISettings"/> of this documentation generation context.
    /// </summary>
    ISettings Settings { get; }

    /// <summary>
    /// Gets all the <see cref="DocItem"/> known by this documentation generation context.
    /// </summary>
    IDictionary<string, DocItem> Items { get; }

    /// <summary>
    /// Gets all the <see cref="DocItem"/> that should generate their own documentation page.
    /// </summary>
    ICollection<DocItem> ItemsWithOwnPage { get; }

    /// <summary>
    /// Gets a <typeparamref name="T"/> setting with the given name.
    /// </summary>
    /// <typeparam name="T">The type of the setting to get.</typeparam>
    /// <param name="name">The name of the setting to get.</param>
    /// <returns>The setting if present, otherwise the default value of the type <typeparamref name="T"/>.</returns>
    T? GetSetting<T>(string name);

    /// <summary>
    /// Gets a <typeparamref name="T"/> setting with the given name for the given <see cref="DocItem"/> <see cref="Type"/>.
    /// </summary>
    /// <typeparam name="T">The type of the setting to get.</typeparam>
    /// <param name="type">The <see cref="DocItem"/> <see cref="Type"/> for which to get the specific setting.</param>
    /// <param name="name">The name of the setting to get.</param>
    /// <returns>The setting if present, otherwise the default value of the type <typeparamref name="T"/>.</returns>
    T? GetSetting<T>(Type? type, string name);
}
