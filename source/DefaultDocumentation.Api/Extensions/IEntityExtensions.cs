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
            Accessibility.Public => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Public) != 0,
            Accessibility.Private => entity switch
            {
                IProperty property when property.IsExplicitInterfaceImplementation => property.ExplicitlyImplementedInterfaceMembers.First().DeclaringTypeDefinition.IsVisibleInDocumentation(settings),
                IMethod method when method.IsExplicitInterfaceImplementation => method.ExplicitlyImplementedInterfaceMembers.First().DeclaringTypeDefinition.IsVisibleInDocumentation(settings),
                _ => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Private) != 0
            },
            Accessibility.Protected => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Protected) != 0,
            Accessibility.Internal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.Internal) != 0,
            Accessibility.ProtectedOrInternal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.ProtectedInternal) != 0,
            Accessibility.ProtectedAndInternal => (settings.GeneratedAccessModifiers & GeneratedAccessModifiers.PrivateProtected) != 0,
            _ => false
        };
    }
}
