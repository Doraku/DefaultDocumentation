using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(HomeDocItem parent, string name, XElement documentation)
            : base(parent, $"N:{name}", name, name, documentation)
        { }
    }
}
