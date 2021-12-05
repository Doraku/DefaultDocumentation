using System;
using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    /// <summary>
    /// Represents an <see cref="IField"/> documentation.
    /// </summary>
    public sealed class FieldDocItem : EntityDocItem
    {
        /// <summary>
        /// Gets the <see cref="IField"/> of the current instance.
        /// </summary>
        public IField Field { get; }

        /// <summary>
        /// Initialize a new instance of the <see cref="FieldDocItem"/> type.
        /// </summary>
        /// <param name="parent">The <see cref="TypeDocItem"/> parent type of the field.</param>
        /// <param name="field">The <see cref="IField"/> of the field.</param>
        /// <param name="documentation">The <see cref="XElement"/> documentation element of the field.</param>
        public FieldDocItem(TypeDocItem parent, IField field, XElement? documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  field ?? throw new ArgumentNullException(nameof(field)),
                  documentation)
        {
            Field = field;
        }
    }
}
