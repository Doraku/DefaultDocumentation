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

        /// <summary>
        /// Initialize a new instance of the <see cref="EnumFieldDocItem"/> type.
        /// </summary>
        /// <param name="parent">The <see cref="EnumDocItem"/> parent enum of the enum field.</param>
        /// <param name="field">The <see cref="IField"/> of the enum field.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the enum field.</param>
        public EnumFieldDocItem(EnumDocItem parent, IField field, XElement? documentation)
            : base(
                  parent ?? throw new System.ArgumentNullException(nameof(parent)),
                  field ?? throw new System.ArgumentNullException(nameof(field)),
                  documentation)
        {
            Field = field;
        }
    }
}
