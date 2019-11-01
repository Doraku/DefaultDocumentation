using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class TypeDocItem : DocItem, ITypeParameterizedDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new CSharpAmbience
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
        };

        public ITypeDefinition Type { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, Type.Kind.ToString());

            writer.Write(this, Documentation.GetSummary());

            writer.WriteLine("```C#");
            writer.WriteLine(CodeAmbience.ConvertSymbol(Type));
            writer.WriteLine("```");

            //inheritance

            // attribute

            // implements

            writer.WriteDocItems(TypeParameters, "#### Type parameters");

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            writer.WriteChildrenLink<ConstructorDocItem>("Constructors");
            writer.WriteChildrenLink<FieldDocItem>("Fields");
            writer.WriteChildrenLink<PropertyDocItem>("Properties");
            writer.WriteChildrenLink<MethodDocItem>("Methods");
            writer.WriteChildrenLink<EventDocItem>("Events");
            writer.WriteChildrenLink<OperatorDocItem>("Operators");
        }
    }
}
