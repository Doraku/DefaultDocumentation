namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes methods related to the documentation files cleaning and creation.
    /// </summary>
    public interface IUrlFactory
    {
        /// <summary>
        /// Gets the name of the factory, used to identify it at the configuration level.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets thr url of the given id.
        /// </summary>
        /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation generation process.</param>
        /// <param name="id">The id to get the url for.</param>
        /// <returns>The url of the given id.</returns>
        string? GetUrl(IGeneralContext context, string id);
    }
}
