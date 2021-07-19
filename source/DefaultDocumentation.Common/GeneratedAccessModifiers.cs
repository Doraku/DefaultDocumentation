using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum GeneratedAccessModifiers
    {
        Default = 0,
        Public = 1 << 0,
        Private = 1 << 1,
        Protected = 1 << 2,
        Internal = 1 << 3,
        ProtectedInternal = 1 << 4,
        PrivateProtected = 1 << 5,
    }
}
