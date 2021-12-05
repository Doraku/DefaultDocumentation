using System;

namespace DefaultDocumentation
{
    /// <summary>
    /// Specifies a combination of page kinds.
    /// </summary>
    [Flags]
    public enum GeneratedPages
    {
        /// <summary>
        /// Generates all documentation page kinds.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Generates documentation page for the assembly.
        /// </summary>
        Assembly = 1 << 0,
        /// <summary>
        /// Generates documentation pages for the namespaces.
        /// </summary>
        Namespaces = 1 << 1,
        /// <summary>
        /// Generates documentation pages for the classes.
        /// </summary>
        Classes = 1 << 2,
        /// <summary>
        /// Generates documentation pages for the delegates.
        /// </summary>
        Delegates = 1 << 3,
        /// <summary>
        /// Generates documentation pages for the enums.
        /// </summary>
        Enums = 1 << 4,
        /// <summary>
        /// Generates documentation pages for the structs.
        /// </summary>
        Structs = 1 << 5,
        /// <summary>
        /// Generates documentation pages for the interfaces.
        /// </summary>
        Interfaces = 1 << 6,
        /// <summary>
        /// Generates documentation pages for all type kinds (class, delegate, enum, struct, interface).
        /// </summary>
        Types = Classes | Delegates | Enums | Structs | Interfaces,
        /// <summary>
        /// Generates documentation pages for the constructors.
        /// </summary>
        Constructors = 1 << 7,
        /// <summary>
        /// Generates documentation pages for the events.
        /// </summary>
        Events = 1 << 8,
        /// <summary>
        /// Generates documentation pages for the fields.
        /// </summary>
        Fields = 1 << 9,
        /// <summary>
        /// Generates documentation pages for the methods.
        /// </summary>
        Methods = 1 << 10,
        /// <summary>
        /// Generates documentation pages for the operators.
        /// </summary>
        Operators = 1 << 11,
        /// <summary>
        /// Generates documentation pages for the properties.
        /// </summary>
        Properties = 1 << 12,
        /// <summary>
        /// Generates documentation pages for the explicit interface implementations.
        /// </summary>
        ExplicitInterfaceImplementations = 1 << 13,
        /// <summary>
        /// Generates documentation pages for all member kinds (constructor, event, field, method, operator, property, explicit interface implementation).
        /// </summary>
        Members = Constructors | Events | Fields | Methods | Operators | Properties | ExplicitInterfaceImplementations
    }
}
