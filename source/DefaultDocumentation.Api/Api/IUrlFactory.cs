namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes methods related to the documentation files url creation.
    /// </summary>
    public interface IUrlFactory
    {
        /// <summary>
        /// Gets the name of the factory, used to identify it at the configuration level.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the url of the given id. Returns null of the instance does not know how to handle the provided id.
        /// </summary>
        /// <param name="context">The <see cref="IPageContext"/> of the current documentation generation process.</param>
        /// <param name="id">The id to get the url for.</param>
        /// <returns>The url of the given id.</returns>
        string? GetUrl(IPageContext context, string id);
    }
}
