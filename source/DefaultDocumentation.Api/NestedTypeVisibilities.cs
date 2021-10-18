using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum NestedTypeVisibilities
    {
        Default = 0,
        Namespace = 1,
        DeclaringType = 2
    }
}
