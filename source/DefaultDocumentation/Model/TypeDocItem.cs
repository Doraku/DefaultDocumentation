using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class TypeDocItem : DocItem, ITypeParameterizedDocItem
    {
        public ITypeDefinition Type { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        protected TypeDocItem(ITypeDefinition type, XElement documentation)
            : base(null, type, documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
        }

        private void WriteLinks<T>(DocumentationWriter writer, IEnumerable<DocItem> items, string title)
            where T : DocItem
        {
            bool hasTitle = false;
            foreach (T item in items.OfType<T>().Where(i => i.Parent == this).OrderBy(i => i.Id))
            {
                if (!hasTitle)
                {
                    hasTitle = true;
                    writer.WriteLine($"### {title}");
                }

                writer.WriteLine(item.GetLink(false));
            }
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Name} {Type.Kind}");

            writer.Write(Documentation.GetSummary(), this, items);

            // code

            //inheritance

            // attribute

            // implements

            if (TypeParameters.Length > 0)
            {
                writer.WriteLine("#### Type parameters");
                foreach (TypeParameterDocItem item in TypeParameters)
                {
                    item.WriteDocumentation(writer, items);
                    writer.Break();
                }
            }

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);

            WriteLinks<ConstructorDocItem>(writer, items.Values, "Constructors");
            WriteLinks<FieldDocItem>(writer, items.Values, "Fields");
            WriteLinks<PropertyDocItem>(writer, items.Values, "Properties");
            WriteLinks<MethodDocItem>(writer, items.Values, "Methods");
            WriteLinks<EventDocItem>(writer, items.Values, "Events");
            WriteLinks<OperatorDocItem>(writer, items.Values, "Operators");
        }
    }
}
