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

        private static readonly CSharpAmbience BaseTypeAmbience = new CSharpAmbience
        {
            ConversionFlags = ConversionFlags.ShowTypeParameterList
        };

        public ITypeDefinition Type { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
        }

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteHeader();
            writer.WritePageTitle(Name, Type.Kind.ToString());

            writer.Write(this, Documentation.GetSummary());

            List<IType> interfaces = Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface).ToList();

            writer.WriteLine("```C#");
            writer.Write(CodeAmbience.ConvertSymbol(Type));
            IType baseType = Type.DirectBaseTypes.FirstOrDefault(t => t.Kind == TypeKind.Class && !t.IsKnownType(KnownTypeCode.Object) && !t.IsKnownType(KnownTypeCode.ValueType));
            if (baseType != null)
            {
                writer.Write(" : ");
                writer.Write(BaseTypeAmbience.ConvertType(baseType));
            }
            foreach (IType @interface in interfaces)
            {
                writer.WriteLine(baseType is null ? " :" : ",");
                baseType = Type;
                writer.Write(BaseTypeAmbience.ConvertType(@interface));
            }
            writer.Break();
            writer.WriteLine("```");

            if (Type.Kind == TypeKind.Class)
            {
                writer.Write("Inheritance ");
                writer.Write(string.Join(" &gt; ", Type.GetNonInterfaceBaseTypes().Select(t => writer.GetTypeLink(this, t))));
                writer.WriteLine("  ");
                if (interfaces.Count > 0)
                {
                    writer.Break();
                }
            }

            // attribute

            if (interfaces.Count > 0)
            {
                writer.Write("Implements ");
                writer.Write(string.Join(", ", interfaces.Select(t => writer.GetTypeLink(this, t))));
                writer.WriteLine("  ");
            }

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
