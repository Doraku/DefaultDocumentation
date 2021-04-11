using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Helper
{
    internal static class ITypeExtension
    {
        public static bool IsObjectOrValueType(this IType type)
        {
            ITypeDefinition definition = type.GetDefinition();
            return definition != null && (definition.KnownTypeCode == KnownTypeCode.Object || definition.KnownTypeCode == KnownTypeCode.ValueType);
        }
    }
}
