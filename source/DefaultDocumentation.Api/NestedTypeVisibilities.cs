using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum NestedTypeVisibilities
    {
        Default = 0,
        Namespace = 1 << 0,
        DeclaringType = 1 << 1
    }
}
