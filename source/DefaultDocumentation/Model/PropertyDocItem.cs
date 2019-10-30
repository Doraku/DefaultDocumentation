using System.Xml.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class PropertyDocItem : DocItem
    {
        public IProperty Property { get; }

        public PropertyDocItem(IProperty property, XElement documentation)
            : base(property, documentation)
        {
            Property = property;
        }
    }
}
