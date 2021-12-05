using System;
using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    /// <summary>
    /// Represents an <see cref="IEvent"/> documentation.
    /// </summary>
    public sealed class EventDocItem : EntityDocItem
    {
        /// <summary>
        /// Gets the <see cref="IEvent"/> of the current instance.
        /// </summary>
        public IEvent Event { get; }

        internal EventDocItem(TypeDocItem parent, IEvent @event, XElement? documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  @event ?? throw new ArgumentNullException(nameof(@event)),
                  documentation)
        {
            Event = @event;
        }
    }
}
