using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal interface ITypeParameterizedDocItem
    {
        TypeParameterDocItem[] TypeParameters { get; }
    }

    internal static class ITypeParameterizedDocItemExtensions
    {
        public static string GetConstraints(this ITypeParameterizedDocItem item)
        {
            static IEnumerable<string> GetTypeConstraints(ITypeParameter typeParameter)
            {
                if (typeParameter.HasReferenceTypeConstraint)
                {
                    yield return typeParameter.NullabilityConstraint == Nullability.Nullable ? "class?" : "class";
                }
                else if (typeParameter.HasValueTypeConstraint)
                {
                    yield return typeParameter.HasUnmanagedConstraint ? "unmanaged" : "struct";
                }
                else if (typeParameter.NullabilityConstraint == Nullability.NotNullable)
                {
                    yield return "notnull";
                }
                foreach (TypeConstraint typeConstraint in typeParameter.TypeConstraints.Where(c => !c.Type.IsObjectOrValueType()))
                {
                    yield return TypeDocItem.BaseTypeAmbience.ConvertType(typeConstraint.Type);
                }
                if (typeParameter.HasDefaultConstructorConstraint && !typeParameter.HasValueTypeConstraint)
                {
                    yield return "new()";
                }
            }

            static IEnumerable<string> GetTypesConstraints(IEnumerable<ITypeParameter> typeParameters)
            {
                foreach (ITypeParameter typeParameter in typeParameters)
                {
                    string constaints = string.Join(", ", GetTypeConstraints(typeParameter));
                    if (!string.IsNullOrEmpty(constaints))
                    {
                        yield return $"{Environment.NewLine}    where {typeParameter.Name} : {constaints}";
                    }
                }
            }

            return string.Concat(GetTypesConstraints(item.TypeParameters.Select(i => i.TypeParameter)));
        }
    }
}
