using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;
using Mono.Cecil;

namespace DefaultDocumentation.Model
{
    internal sealed class EventItem : AMemberItem
    {
        public const string Id = "E:";

        public override string Header => "Events";
        public override string Title => "event";

        public EventDefinition Event { get; }

        public EventItem(AMemberItem parent, XElement element)
            : base(parent, element)
        {
            TypeDefinition parentType = (parent as TypeItem).Type;

            Event = parentType.Events.First(e => e.Name == Name);
        }

        public override void Write(Converter converter, DocWriter writer)
        {
            writer.WriteLine($"## {Name} `{Title}`");

            converter.WriteSummary(writer, this);

            TypeReference fieldType = Event.EventType;
            string fieldTypeName = fieldType.FullName.Replace('/', '.');
            converter.Items.TryGetValue($"{TypeItem.Id}{fieldTypeName}", out AMemberItem parentTypeItem);

            writer.WriteLine("```C#");
            writer.Write("public ");
            if (Event.AddMethod?.IsStatic ?? Event.RemoveMethod?.IsStatic ?? false)
            {
                writer.Write("static ");
            }
            writer.WriteLine($"event {parentTypeItem?.FullName ?? fieldTypeName} {Name};");
            writer.WriteLine("```");

            writer.WriteLine("#### Event Type");
            writer.WriteLine(parentTypeItem?.AsLink() ?? fieldTypeName.AsDotNetApiLink());

            base.Write(converter, writer);
        }
    }
}
