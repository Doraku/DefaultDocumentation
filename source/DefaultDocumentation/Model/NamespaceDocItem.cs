using System.Collections.Generic;
using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(HomeDocItem parent, string name, XElement documentation)
            : base(parent, $"N:{name}", name, name, documentation)
        { }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, "Namespace");

            writer.Write(this, Documentation.GetSummary());

            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            writer.WriteChildrenLink<ClassDocItem>("Classes");
            writer.WriteChildrenLink<StructDocItem>("Structs");
            writer.WriteChildrenLink<InterfaceDocItem>("Interfaces");
            writer.WriteChildrenLink<EnumDocItem>("Enums");
            writer.WriteChildrenLink<DelegateDocItem>("Delegates");
        }
    }
}
