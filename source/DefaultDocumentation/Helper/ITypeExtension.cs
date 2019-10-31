using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace DefaultDocumentation.Helper
{
    internal static class ITypeExtension
    {
        public static IType RemoveReference(this IType type) => type is TypeWithElementType realType ? realType.ElementType : type;
    }
}
