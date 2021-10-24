using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class EventDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Events;

        public IEvent Event { get; }

        public EventDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(parent, @event, documentation)
        {
            Event = @event;
        }
    }
}
