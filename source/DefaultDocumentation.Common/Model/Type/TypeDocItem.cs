using System.Linq;
using System.Text;
using System.Xml.Linq;
using DefaultDocumentation.Model.Parameter;
using ICSharpCode.Decompiler.CSharp.OutputVisitor;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model.Type
{
    internal abstract class TypeDocItem : DocItem, ITypeParameterizedDocItem, IDefinedDocItem
    {
        private static readonly CSharpAmbience CodeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowAccessibility
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.ShowDefinitionKeyword
                | ConversionFlags.ShowModifiers
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.ShowTypeParameterVarianceModifier
        };

        public static readonly CSharpAmbience BaseTypeAmbience = new()
        {
            ConversionFlags =
                ConversionFlags.ShowParameterList
                | ConversionFlags.ShowTypeParameterList
                | ConversionFlags.UseFullyQualifiedTypeNames
                | ConversionFlags.ShowDeclaringType
                | ConversionFlags.UseFullyQualifiedEntityNames
        };

        public ITypeDefinition Type { get; }

        public TypeParameterDocItem[] TypeParameters { get; }

        protected TypeDocItem(DocItem parent, ITypeDefinition type, XElement documentation)
            : base(parent, type, documentation)
        {
            Type = type;
            TypeParameters = Type.TypeParameters.Select(p => new TypeParameterDocItem(this, p, documentation)).ToArray();
        }

        public virtual void WriteDefinition(StringBuilder builder)
        {
            builder.Append(CodeAmbience.ConvertSymbol(Type));
            IType baseType = Type.DirectBaseTypes.FirstOrDefault(t => t.Kind == TypeKind.Class && !t.IsKnownType(KnownTypeCode.Object) && !t.IsKnownType(KnownTypeCode.ValueType));
            if (baseType != null)
            {
                builder.Append(" : ").Append(BaseTypeAmbience.ConvertType(baseType));
            }
            foreach (IType @interface in Type.DirectBaseTypes.Where(t => t.Kind == TypeKind.Interface && t.GetDefinition().Accessibility == Accessibility.Public))
            {
                builder.AppendLine(baseType is null ? " :" : ",").Append(BaseTypeAmbience.ConvertType(@interface));
                baseType = Type;
            }
            builder.AppendLine(this.GetConstraints());
        }
    }
}
