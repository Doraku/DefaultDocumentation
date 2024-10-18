using System;
using System.Linq;
using DefaultDocumentation;

namespace ICSharpCode.Decompiler.TypeSystem;

/// <summary>
/// Provides extension methods on the <see cref="IEntity"/> type.
/// </summary>
public static class IEntityExtensions
{
    /// <summary>
    /// Returns wether an <see cref="IEntity"/> should be part of the documentation or not based on its accessibility.
    /// </summary>
    /// <param name="entity">The <see cref="IEntity"/> to check.</param>
    /// <param name="settings">The <see cref="ISettings"/> used to generate the documentation.</param>
    /// <returns><see langword="true"/> if the entity should be part of the documentation; otherwise <see langword="false"/>.</returns>
    public static bool IsVisibleInDocumentation(this IEntity? entity, ISettings settings)
    {
        settings.ThrowIfNull();

        return entity?.EffectiveAccessibility() switch
        {
            Accessibility.Public => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.Public),
            Accessibility.Private => entity switch
            {
                IProperty property when property.IsExplicitInterfaceImplementation => property.ExplicitlyImplementedInterfaceMembers.First().DeclaringTypeDefinition.IsVisibleInDocumentation(settings),
                IMethod method when method.IsExplicitInterfaceImplementation => method.ExplicitlyImplementedInterfaceMembers.First().DeclaringTypeDefinition.IsVisibleInDocumentation(settings),
                _ => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.Private)
            },
            Accessibility.Protected => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.Protected),
            Accessibility.Internal => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.Internal),
            Accessibility.ProtectedOrInternal => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.ProtectedInternal),
            Accessibility.ProtectedAndInternal => settings.GeneratedAccessModifiers.HasFlag(GeneratedAccessModifiers.PrivateProtected),
            _ => false
        };
    }
}
