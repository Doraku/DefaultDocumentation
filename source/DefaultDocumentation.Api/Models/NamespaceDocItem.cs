using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    /// <summary>
    /// Represents a namespace documentation.
    /// </summary>
    public sealed class NamespaceDocItem : DocItem
    {
        internal NamespaceDocItem(AssemblyDocItem parent, string name, XElement? documentation)
            : base(parent ?? throw new ArgumentNullException(nameof(parent)), $"N:{name}", name, name, documentation)
        { }
    }
}
