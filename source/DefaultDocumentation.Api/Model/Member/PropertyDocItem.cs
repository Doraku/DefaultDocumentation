using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    public sealed class PropertyDocItem : DocItem, IParameterizedDocItem
    {
        public override GeneratedPages Page => GeneratedPages.Properties;

        public IProperty Property { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public PropertyDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(parent, property, documentation)
        {
            Property = property;
            Parameters = Property.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }
    }
}
