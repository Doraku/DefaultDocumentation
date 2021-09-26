using System.Linq;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Helper
{
    internal static class IEntityExtension
    {
        public static bool IsDefaultConstructor(this IEntity entity) =>
            entity is IMethod method && method.IsConstructor
            && method.Parameters.Count is 0
            && ((method.DeclaringType.Kind is TypeKind.Struct or TypeKind.Enum) || method.DeclaringTypeDefinition.GetConstructors().Count() == 1);
    }
}
