using System;
using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    /// <summary>
    /// Represents an enum <see cref="IField"/> documentation.
    /// </summary>
    public sealed class EnumFieldDocItem : EntityDocItem
    {
        /// <summary>
        /// Gets the <see cref="IField"/> of the current instance.
        /// </summary>
        public IField Field { get; }

        internal EnumFieldDocItem(EnumDocItem parent, IField field, XElement? documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  field ?? throw new ArgumentNullException(nameof(field)),
                  documentation)
        {
            Field = field;
        }
    }
}
