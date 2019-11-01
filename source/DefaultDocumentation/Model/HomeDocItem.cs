using System.Collections.Generic;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        public HomeDocItem(string name)
            : base(null, string.Empty, "index", name, null)
        { }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();

            writer.WriteChildrenLink<NamespaceDocItem>("Namespaces");
        }
    }
}
