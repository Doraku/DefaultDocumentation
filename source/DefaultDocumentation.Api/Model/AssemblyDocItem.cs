using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    public sealed class AssemblyDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Assembly;

        public AssemblyDocItem(string pageName, string name, XElement documentation)
            : base(null, string.Empty, pageName ?? "index", name, documentation)
        { }
    }
}
