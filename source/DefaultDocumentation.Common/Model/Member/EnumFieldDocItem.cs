using System.Xml.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class EnumFieldDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Default;

        public IField Field { get; }

        public EnumFieldDocItem(EnumDocItem parent, IField field, XElement documentation)
            : base(parent, field, documentation)
        {
            Field = field;
        }
    }
}
