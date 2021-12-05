namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes a method to write a specific section when writing documentation.
    /// </summary>
    public interface ISection
    {
        /// <summary>
        /// Gets the name of the section, used to identify it at the configuration level.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Writes the section to a given <see cref="IWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> to write to.</param>
        void Write(IWriter writer);
    }
}
