using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class EventDocItem : DocItem, IDefinedDocItem
    {
        public static readonly CSharpAmbience CodeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
        };

        public override GeneratedPages Page => GeneratedPages.Events;

        public IEvent Event { get; }

        public EventDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(parent, @event, documentation)
        {
            Event = @event;
        }

        public void WriteDefinition(StringBuilder builder) => builder.AppendLine(CodeAmbience.ConvertSymbol(Event));
    }
}
