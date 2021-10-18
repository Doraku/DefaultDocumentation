using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Member
{
    internal sealed class PropertyDocItem : DocItem, IParameterizedDocItem, IDefinedDocItem
    {
        public static readonly CSharpAmbience CodeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowBody
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowParameterDefaultValues
                | ConversionFlags.ShowParameterList
                | ConversionFlags.ShowParameterModifiers
                | ConversionFlags.ShowParameterNames
                | ConversionFlags.ShowReturnType
                | ConversionFlags.UseFullyQualifiedTypeNames
        };

        public override GeneratedPages Page => GeneratedPages.Properties;

        public IProperty Property { get; }

        public ParameterDocItem[] Parameters { get; }

        public PropertyDocItem(TypeDocItem parent, IProperty property, XElement documentation)
            : base(parent, property, documentation)
        {
            Property = property;
            Parameters = Property.Parameters.Select(p => new ParameterDocItem(this, p, documentation)).ToArray();
        }

        public XElement Definition => new("code", CodeAmbience.ConvertSymbol(Property));
    }
}
