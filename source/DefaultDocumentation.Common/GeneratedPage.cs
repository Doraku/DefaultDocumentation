using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum GeneratedPage
    {
        Default = 0,
        Namespaces = 1 << 0,
        Types = 1 << 1,
        Members = 1 << 2
    }
}
