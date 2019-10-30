using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class FieldDocItem : DocItem
    {
        public IField Field { get; }

        public FieldDocItem(IField field, XElement documentation)
            : base(field, documentation)
        {
            Field = field;
        }
    }
}
