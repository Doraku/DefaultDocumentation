using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(HomeDocItem parent, string name, XElement documentation)
            : base(parent, $"N:{name}", name, name, documentation)
        { }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, "Namespace");

            writer.Write(this, Documentation.GetSummary());

            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            if (writer.NestedTypeVisibility == NestedTypeVisibility.Namespace
                || writer.NestedTypeVisibility == NestedTypeVisibility.Everywhere)
            {
                writer.WriteChildrenLink<ClassDocItem>("Classes");
                writer.WriteChildrenLink<StructDocItem>("Structs");
                writer.WriteChildrenLink<InterfaceDocItem>("Interfaces");
                writer.WriteChildrenLink<EnumDocItem>("Enums");
                writer.WriteChildrenLink<DelegateDocItem>("Delegates");
            }
            else
            {
                writer.WriteDirectChildrenLink<ClassDocItem>("Classes");
                writer.WriteDirectChildrenLink<StructDocItem>("Structs");
                writer.WriteDirectChildrenLink<InterfaceDocItem>("Interfaces");
                writer.WriteDirectChildrenLink<EnumDocItem>("Enums");
                writer.WriteDirectChildrenLink<DelegateDocItem>("Delegates");
            }
        }
    }
}
