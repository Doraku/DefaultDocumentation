using System;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Api
{
    /// <summary>
    /// Exposes properties and methods use to generate a documentation file for a specific <see cref="Models.DocItem"/>.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Gets the <see cref="IGeneralContext"/> of the current documentation generation process.
        /// </summary>
        IGeneralContext Context { get; }

        /// <summary>
        /// Gets the <see cref="Models.DocItem"/> for which the documentation is being generated.
        /// </summary>
        DocItem DocItem { get; }

        /// <summary>
        /// Gets or sets the length of the documentation text currently produced.
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Gets or sets extra data for the current <see cref="Models.DocItem"/> documentation generation.
        /// </summary>
        /// <param name="key">The key of the data.</param>
        /// <returns>The value of the data.</returns>
        object? this[string key] { get; set; }

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
