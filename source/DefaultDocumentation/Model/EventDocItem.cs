using System.Collections.Generic;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class EventDocItem : DocItem
    {
        public IEvent Event { get; }

        public EventDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(parent, @event, documentation)
        {
            Event = @event;
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader(this, items);

            writer.WriteLine($"## {Parent.Name}{Name} Event");

            writer.Write(Documentation.GetSummary(), this, items);

            // code
            // attributes

            writer.WriteLine("#### Event type");
            //writer.WriteLine(items.TryGetValue(Event..Type.GetDefinition().GetIdString(), out DocItem type) ? type.GetLink() : Field.Type.FullName); // dotnetapi link

            writer.Write("### Example", Documentation.GetExample(), this, items);
            writer.Write("### Remarks", Documentation.GetRemarks(), this, items);
        }
    }
}
