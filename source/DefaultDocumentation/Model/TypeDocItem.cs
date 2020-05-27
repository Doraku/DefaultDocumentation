using System;
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

            List<IType> interfaces = Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface && t.GetDefinition().Accessibility == Accessibility.Public).ToList();

            writer.WriteLine("```csharp");
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

            bool needBreak = false;

            if (Type.Kind == TypeKind.Class)
            {
                writer.Write("Inheritance ");
                writer.Write(string.Join(" &#129106; ", Type.GetNonInterfaceBaseTypes().Where(t => t != Type).Select(writer.GetTypeLink)));
                writer.Write(" &#129106; ");
                writer.Write(Name);
                writer.WriteLine("  ");
                needBreak = true;
            }

            List<TypeDocItem> derived = writer.KnownItems.OfType<TypeDocItem>().Where(i => i.Type.DirectBaseTypes.Select(t => t is ParameterizedType g ? g.GetDefinition() : t).Contains(Type)).OrderBy(i => i.FullName).ToList();
            if (derived.Count > 0)
            {
                if (needBreak)
                {
                    writer.Break();
                }

                writer.Write("Derived  " + Environment.NewLine + "&#8627; ");
                writer.Write(string.Join("  " + Environment.NewLine + "&#8627; ", derived.Select(t => writer.GetLink(t))));
                writer.WriteLine("  ");
                needBreak = true;
            }

            // attribute

            if (interfaces.Count > 0)
            {
                if (needBreak)
                {
                    writer.Break();
                }

                writer.Write("Implements ");
                writer.Write(string.Join(", ", interfaces.Select(writer.GetTypeLink)));
                writer.WriteLine("  ");
            }

            writer.WriteDocItems(TypeParameters, "#### Type parameters");

            writer.Write("### Example", Documentation.GetExample(), this);
            writer.Write("### Remarks", Documentation.GetRemarks(), this);

            writer.WriteDirectChildrenLink<ConstructorDocItem>("Constructors");
            writer.WriteDirectChildrenLink<FieldDocItem>("Fields");
            writer.WriteDirectChildrenLink<PropertyDocItem>("Properties");
            writer.WriteDirectChildrenLink<MethodDocItem>("Methods");
            writer.WriteDirectChildrenLink<EventDocItem>("Events");
            writer.WriteDirectChildrenLink<OperatorDocItem>("Operators");

            if (writer.NestedTypeVisibility == NestedTypeVisibility.DeclaringType
                || writer.NestedTypeVisibility == NestedTypeVisibility.Everywhere)
            {
                writer.WriteDirectChildrenLink<ClassDocItem>("Classes");
                writer.WriteDirectChildrenLink<StructDocItem>("Structs");
                writer.WriteDirectChildrenLink<InterfaceDocItem>("Interfaces");
                writer.WriteDirectChildrenLink<EnumDocItem>("Enums");
                writer.WriteDirectChildrenLink<DelegateDocItem>("Delegates");
            }
        }
    }
}
