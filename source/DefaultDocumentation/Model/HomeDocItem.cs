using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        private readonly bool _explicitGenerate;

        public bool HasMultipleNamespaces { get; set; }

        public HomeDocItem(string pageName, string name, XElement documentation)
            : base(null, string.Empty, pageName ?? "index", name, documentation)
        {
            _explicitGenerate = !string.IsNullOrEmpty(pageName) || documentation != null;
        }

        public override bool GeneratePage => _explicitGenerate || HasMultipleNamespaces;

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();

            writer.Write(this, Documentation.GetSummary());

            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            writer.WriteChildrenLink<NamespaceDocItem>("Namespaces");
        }
    }
}
