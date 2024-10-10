using DefaultDocumentation.Models;

namespace DefaultDocumentation;

/// <summary>
/// Exposes settings used to generate documentation for a specific <see cref="Models.DocItem"/>.
/// </summary>
public interface IPageContext : IGeneralContext
{
    /// <summary>
    /// Gets the <see cref="Models.DocItem"/> for which the documentation is being generated.
    /// </summary>
    DocItem DocItem { get; }

    /// <summary>
    /// Gets or sets extra data for the current <see cref="Models.DocItem"/> documentation generation.
    /// </summary>
    /// <param name="key">The key of the data.</param>
    /// <returns>The value of the data.</returns>
    object? this[string key] { get; set; }
}
