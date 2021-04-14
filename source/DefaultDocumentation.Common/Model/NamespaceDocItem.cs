using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(AssemblyDocItem parent, string name, XElement documentation)
            : base(parent, $"N:{name}", name, name, documentation)
        { }
    }
}
