using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum GeneratedPages
    {
        Default = 0,
        Home = 1 << 0,
        Namespaces = 1 << 1,
        Types = 1 << 2,
        Members = 1 << 3
    }
}
