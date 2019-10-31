using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DefaultDocumentation.Model
{
    internal sealed class HomeDocItem : DocItem
    {
        public HomeDocItem(string id)
            : base(null, id, new XElement("doc"))
        { }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteLine($"#### {GetLink()}");

            foreach (IGrouping<string, TypeDocItem> group in items.Values.OfType<TypeDocItem>().GroupBy(i => i.Type.Namespace).OrderBy(g => g.Key))
            {
                writer.WriteLine($"### {group.Key}");

                foreach (TypeDocItem item in group.OrderBy(i => i.Type.FullName))
                {
                    writer.WriteLine($"- {item.GetLink(false)}");
                }
            }
        }
    }
}
