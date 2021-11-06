using System;
using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    public sealed class EventDocItem : EntityDocItem
    {
        public IEvent Event { get; }

        public EventDocItem(TypeDocItem parent, IEvent @event, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  @event ?? throw new ArgumentNullException(nameof(@event)),
                  documentation)
        {
            Event = @event;
        }
    }
}
