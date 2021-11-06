using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models.Parameters;
using DefaultDocumentation.Models.Types;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Models.Members
{
    public sealed class PropertyDocItem : EntityDocItem, IParameterizedDocItem
    {
        public IProperty Property { get; }

        public IEnumerable<ParameterDocItem> Parameters { get; }

        public PropertyDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(
                  parent ?? throw new ArgumentNullException(nameof(parent)),
                  property ?? throw new ArgumentNullException(nameof(property)),
                  documentation)
        {
            Property = property;
            Parameters = Property.Parameters.Select(p => new ParameterDocItem(this, p)).ToArray();
        }
    }
}
