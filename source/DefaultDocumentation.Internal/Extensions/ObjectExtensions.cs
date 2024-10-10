using System.Runtime.CompilerServices;

namespace System;

internal static class ObjectExtensions
{
    public static T ThrowIfNull<T>(this T? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        => argument ?? throw new ArgumentNullException(paramName);
}