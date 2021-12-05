using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    /// <summary>
    /// Represents an assembly documentation.
    /// </summary>
    public sealed class AssemblyDocItem : DocItem
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="AssemblyDocItem"/> type.
        /// </summary>
        /// <param name="fullName">The full name of the assembly.</param>
        /// <param name="name">The name of the assemby.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the assembly.</param>
        public AssemblyDocItem(string fullName, string name, XElement? documentation)
            : base(null, string.Empty, fullName, name, documentation)
        { }
    }
}
