using System.Collections.Generic;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceDocItem : DocItem
    {
        public NamespaceDocItem(string name)
            : base(null, $"N:{name}", name, name, null)
        { }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, "Namespace");

            writer.WriteChildrenLink<ClassDocItem>("Classes");
            writer.WriteChildrenLink<StructDocItem>("Structs");
            writer.WriteChildrenLink<InterfaceDocItem>("Interfaces");
            writer.WriteChildrenLink<EnumDocItem>("Enums");
            writer.WriteChildrenLink<DelegateDocItem>("Delegates");
        }
    }
}
