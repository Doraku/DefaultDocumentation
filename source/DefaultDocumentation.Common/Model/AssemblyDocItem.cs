using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class AssemblyDocItem : DocItem
    {
        public AssemblyDocItem(string pageName, string name, XElement documentation)
            : base(null, string.Empty, pageName ?? "index", name, documentation)
        { }
    }
}
