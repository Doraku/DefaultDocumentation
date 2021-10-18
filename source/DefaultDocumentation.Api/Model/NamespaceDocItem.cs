using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    public sealed class NamespaceDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Namespaces;

        public NamespaceDocItem(AssemblyDocItem parent, string name, XElement documentation)
            : base(parent, $"N:{name}", name, name, documentation)
        { }
    }
}
