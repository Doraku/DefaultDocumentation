using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    public sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(AssemblyDocItem parent, string name, XElement documentation)
            : base(parent ?? throw new ArgumentNullException(nameof(parent)), $"N:{name}", name, name, documentation)
        { }
    }
}
