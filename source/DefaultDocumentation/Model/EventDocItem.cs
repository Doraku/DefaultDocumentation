using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class EventDocItem : DocItem
    {
        public IEvent Event { get; }

        public EventDocItem(IEvent @event, XElement documentation)
            : base(@event, documentation)
        {
            Event = @event;
        }
    }
}
