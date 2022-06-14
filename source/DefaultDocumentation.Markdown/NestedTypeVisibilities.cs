using System;

namespace DefaultDocumentation
{
    /// <summary>
    /// Specifies where nested types should be displayed in the generated documentation.
    /// </summary>
    [Flags]
    public enum NestedTypeVisibilities
    {
        /// <summary>
        /// Same as <see cref="Namespace"/>.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Generates nested types in namespace page.
        /// </summary>
        Namespace = 1 << 0,

        /// <summary>
        /// Generates nested types in declaring type page.
        /// </summary>
        DeclaringType = 1 << 1
    }
}
