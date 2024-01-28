using System;

namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes properties and methods use to generate a documentation file for a specific <see cref="Models.DocItem"/>.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Gets the <see cref="IPageContext"/> of the current documentation generation process.
        /// </summary>
        IPageContext Context { get; }

        /// <summary>
        /// Gets or sets the length of the documentation text currently produced.
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Appends a string at the end of the documentation text.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The current <see cref="IWriter"/>.</returns>
        IWriter Append(string value);

        /// <summary>
        /// Appends a <see cref="Environment.NewLine"/> at the end of the documentation text.
        /// </summary>
        /// <returns>The current <see cref="IWriter"/>.</returns>
        IWriter AppendLine();

        /// <summary>
        /// Returns whether the documentation text ends with the given string.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to check.</param>
        /// <returns><see langword="true"/> if the documentation text ends with <paramref name="value"/>, else <see langword="false"/>.</returns>
        bool EndsWith(string value);
    }
}
