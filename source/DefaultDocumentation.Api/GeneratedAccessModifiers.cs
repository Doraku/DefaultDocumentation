using System;

namespace DefaultDocumentation
{
    /// <summary>
    /// Specifies a combination of access modifiers.
    /// </summary>
    [Flags]
    public enum GeneratedAccessModifiers
    {
        /// <summary>
        /// Generates documentation for all access modifiers.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Generates documentation for 'public' access modifier.
        /// </summary>
        Public = 1 << 0,
        /// <summary>
        /// Generates documentation for 'private' access modifier.
        /// </summary>
        Private = 1 << 1,
        /// <summary>
        /// Generates documentation for 'protected' access modifier.
        /// </summary>
        Protected = 1 << 2,
        /// <summary>
        /// Generates documentation for 'internal' access modifier.
        /// </summary>
        Internal = 1 << 3,
        /// <summary>
        /// Generates documentation for 'protected internal' access modifier.
        /// </summary>
        ProtectedInternal = 1 << 4,
        /// <summary>
        /// Generates documentation for 'private protected' access modifier.
        /// </summary>
        PrivateProtected = 1 << 5,
        /// <summary>
        /// Generates documentation for 'public', 'protected' and 'protected internal' access modifier.
        /// </summary>
        Api = Public | Protected | ProtectedInternal
    }
}
