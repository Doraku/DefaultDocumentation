using System.Collections.Generic;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        public HomeDocItem()
            : base(null, "index", "index", "index", null)
        { }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();

            writer.WriteChildrenLink<NamespaceDocItem>("Namespaces");
        }
    }
}
