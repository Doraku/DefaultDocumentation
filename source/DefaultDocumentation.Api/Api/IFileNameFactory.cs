using DefaultDocumentation.Models;

namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes methods related to the documentation files cleaning and creation.
    /// </summary>
    public interface IFileNameFactory
    {
        /// <summary>
        /// Gets the name of the factory, used to identify it at the configuration level.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Cleans the <see cref="ISettings.OutputDirectory"/> of the previously generated documentation files.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
        void Clean(IGeneralContext context);

        /// <summary>
        /// Gets the documentation file name for the given <see cref="DocItem"/>.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
        /// <param name="item">The <see cref="DocItem"/> for which to get the documentation file name.</param>
        /// <returns>The documentation file name of the given <see cref="DocItem"/>.</returns>
        string GetFileName(IGeneralContext context, DocItem item);
    }
}
