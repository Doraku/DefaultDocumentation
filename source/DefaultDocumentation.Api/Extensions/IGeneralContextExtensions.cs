using System;
using DefaultDocumentation.Models;

namespace DefaultDocumentation;

/// <summary>
/// Provides extension methods on the <see cref="IGeneralContext"/> type.
/// </summary>
public static class IGeneralContextExtensions
{
    /// <summary>
    /// Gets the specific <see cref="IContext"/> for the given <see cref="DocItem"/> kind.
    /// </summary>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to get a specific <see cref="IContext"/>.</param>
    /// <returns>The <see cref="IContext"/> specific to the provided <see cref="DocItem"/>.</returns>
    public static IContext GetContext(this IGeneralContext context, DocItem item)
    {
        context.ThrowIfNull();
        item.ThrowIfNull();

        return context.GetContext(item.GetType());
    }

    /// <summary>
    /// Gets a data from the specific <see cref="IContext"/> of the provided <see cref="Type"/> if it exists, else from the <see cref="IGeneralContext"/>.
    /// </summary>
    /// <typeparam name="T">The type of the data to get.</typeparam>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <param name="type">The <see cref="Type"/> for which to get a specific setting.</param>
    /// <param name="getter">The <see cref="Func{IContext, T}"/> used to get the setting from a <see cref="IContext"/>.</param>
    /// <returns>The <typeparamref name="T"/> settings from the specific <see cref="IContext"/> if it exists, otherwise from the <see cref="IGeneralContext"/>.</returns>
    /// <remarks>The <typeparamref name="T"/> should be <see cref="Nullable{T}"/> for struct settings.</remarks>
    public static T? GetSetting<T>(this IGeneralContext context, Type? type, Func<IContext, T?> getter)
    {
        context.ThrowIfNull();
        getter.ThrowIfNull();

        return getter(context.GetContext(type)) ?? getter(context);
    }

    /// <summary>
    /// Gets a data from the specific <see cref="IContext"/> of the provided <see cref="DocItem"/> if it exists, else from the <see cref="IGeneralContext"/>.
    /// </summary>
    /// <typeparam name="T">The type of the data to get.</typeparam>
    /// <param name="context">The <see cref="IGeneralContext"/> of the current documentation file.</param>
    /// <param name="item">The <see cref="DocItem"/> for which to get a specific setting.</param>
    /// <param name="getter">The <see cref="Func{IContext, T}"/> used to get the setting from a <see cref="IContext"/>.</param>
    /// <returns>The <typeparamref name="T"/> settings from the specific <see cref="IContext"/> if it exists, otherwise from the <see cref="IGeneralContext"/>.</returns>
    /// <remarks>The <typeparamref name="T"/> should be <see cref="Nullable{T}"/> for struct settings.</remarks>
    public static T? GetSetting<T>(this IGeneralContext context, DocItem item, Func<IContext, T?> getter)
    {
        context.ThrowIfNull();
        item.ThrowIfNull();
        getter.ThrowIfNull();

        return context.GetSetting(item.GetType(), getter);
    }
}
