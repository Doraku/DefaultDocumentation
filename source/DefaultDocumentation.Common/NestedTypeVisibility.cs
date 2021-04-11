using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum NestedTypeVisibility
    {
        Default = 0,
        Namespace = 1,
        DeclaringType = 2
    }
}
