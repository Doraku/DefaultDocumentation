using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        public HomeDocItem(string name, XElement documentation)
            : base(null, string.Empty, "index", name, documentation)
        { }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();

            writer.Write(this, Documentation.GetSummary());

            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            writer.WriteChildrenLink<NamespaceDocItem>("Namespaces");
        }
    }
}
