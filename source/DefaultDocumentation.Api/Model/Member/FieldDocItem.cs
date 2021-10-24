using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class FieldDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Fields;

        public IField Field { get; }

        public FieldDocItem(TypeDocItem parent, IField field, XElement documentation)
            : base(parent, field, documentation)
        {
            Field = field;
        }
    }
}
