using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        public HomeDocItem(string pageName, string name, XElement documentation)
            : base(null, string.Empty, pageName ?? "index", name, documentation)
        { }
    }
}
