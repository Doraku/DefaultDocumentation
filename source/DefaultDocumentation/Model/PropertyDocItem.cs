using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyDocItem : DocItem, IParameterizedDocItem
    {
        public IProperty Property { get; }

        public ParameterDocItem[] Parameters { get; }

        public PropertyDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(parent, property, documentation)
        {
            Property = property;
            Parameters = Property.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Parent.Name}{Name} Property");

            writer.Write(Documentation.GetSummary(), this, items);

            // code

            // attributes

            if (Parameters.Length > 0)
            {
                writer.WriteLine("#### Parameters");
                foreach (ParameterDocItem item in Parameters)
                {
                    item.WriteDocumentation(writer, items);
                    writer.Break();
                }
            }

            writer.WriteLine("#### Property Value");
            writer.Write(items.TryGetValue(Property.ReturnType.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : Property.ReturnType.FullName); // dotnetapi link
            writer.WriteLine("  ");
            writer.Write(Documentation.GetValue(), this, items);

            writer.WriteExceptions(this, items);

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}
