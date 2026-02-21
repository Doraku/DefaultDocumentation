using System;

namespace DefaultDocumentation.Models;

/// <summary>
/// Represent an external documentation.
/// </summary>
public sealed class ExternDocItem : DocItem
{
    /// <summary>
    /// Gets the url of the current instance.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="ExternDocItem"/> type.
    /// </summary>
    /// <param name="id">The id of the external item.</param>
    /// <param name="url">The url of the documentation.</param>
    /// <param name="name">The name of the external item.</param>
    public ExternDocItem(string id, string url, string? name)
        : base(
              null,
              id,
              id?[2..] ?? throw new ArgumentNullException(nameof(id)),
              name ?? id?[2..] ?? throw new ArgumentNullException(nameof(id)),
              null)
    {
        ArgumentNullException.ThrowIfNull(url);

        Url = url;
    }
}
