using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class EnumFieldDocItem : DocItem
    {
        public IField Field { get; }

        public EnumFieldDocItem(EnumDocItem parent, IField field, XElement documentation)
            : base(parent, field, documentation)
        {
            Field = field;
        }
    }
}
