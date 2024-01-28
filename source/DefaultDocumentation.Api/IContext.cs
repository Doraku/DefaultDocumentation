using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation
{
    /// <summary>
    /// Exposes settings used to generate documentation for a given <see cref="DocItem"/> type.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets the <see cref="IFileNameFactory"/> to use to generate a file for a documentation page.
        /// </summary>
        IFileNameFactory? FileNameFactory { get; }

        /// <summary>
        /// Gets the <see cref="ISection"/> to use to generate a documentation page.
        /// </summary>
        IEnumerable<ISection>? Sections { get; }

        /// <summary>
        /// Gets a <typeparamref name="T"/> setting with the given name.
        /// </summary>
        /// <typeparam name="T">The type of the setting to get.</typeparam>
        /// <param name="name">The name of the setting to get.</param>
        /// <returns>The setting if present, otherwise the default value of the type <typeparamref name="T"/>.</returns>
        T? GetSetting<T>(string name);
    }
}
