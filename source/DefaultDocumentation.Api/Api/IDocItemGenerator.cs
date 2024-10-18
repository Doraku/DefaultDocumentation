using DefaultDocumentation.Models;

namespace DefaultDocumentation.Api;

/// <summary>
/// Exposes a method to generate the known <see cref="DocItem"/> of the documentation.
/// </summary>
public interface IDocItemGenerator
{
    /// <summary>
    /// Gets the name of the generator, used to identify it at the configuration level.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Modified the known <see cref="DocItem"/> of the <see cref="IDocItemsContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="IDocItemsContext"/> of the documentation generation.</param>
    void Generate(IDocItemsContext context);
}
