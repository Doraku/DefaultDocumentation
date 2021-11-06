using System;
using System.Xml.Linq;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    public sealed class FieldDocItem : EntityDocItem
    {
        public IField Field { get; }

        public FieldDocItem(TypeDocItem parent, IField field, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  field ?? throw new ArgumentNullException(nameof(field)),
                  documentation)
        {
            Field = field;
        }
    }
}
