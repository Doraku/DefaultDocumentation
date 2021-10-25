namespace ICSharpCode.Decompiler.TypeSystem
{
    internal static class ITypeExtension
    {
        public static bool IsObjectOrValueType(this IType type) => type.GetDefinition()?.KnownTypeCode switch
        {
            KnownTypeCode.Object => true,
            KnownTypeCode.ValueType => true,
            _ => false
        };
    }
}
