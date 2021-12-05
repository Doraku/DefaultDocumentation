using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    /// <summary>
    /// Represents an assembly documentation.
    /// </summary>
    public sealed class AssemblyDocItem : DocItem
    {
        internal AssemblyDocItem(string fullName, string name, XElement? documentation)
            : base(null, string.Empty, fullName, name, documentation)
        { }
    }
}
