using System;

namespace DefaultDocumentation
{
    [Flags]
    public enum GeneratedPages
    {
        Default = 0,
        Assembly = 1 << 0,
        Namespaces = 1 << 1,
        Classes = 1 << 2,
        Delegates = 1 << 3,
        Enums = 1 << 4,
        Structs = 1 << 5,
        Interfaces = 1 << 6,
        Types = Classes | Delegates | Enums | Structs | Interfaces,
        Constructors = 1 << 7,
        Events = 1 << 8,
        Fields = 1 << 9,
        Methods = 1 << 10,
        Operators = 1 << 11,
        Properties = 1 << 12,
        ExplicitInterfaceImplementations = 1 << 13,
        Members = Constructors | Events | Fields | Methods | Operators | Properties | ExplicitInterfaceImplementations
    }
}
