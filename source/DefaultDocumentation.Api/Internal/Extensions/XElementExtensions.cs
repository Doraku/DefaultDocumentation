using System.Collections.Generic;

namespace System.Xml.Linq;

internal static class XElementExtensions
{
    public static IEnumerable<XElement> GetTypeParameters(this XElement? element) => element?.Elements("typeparam") ?? [];

    public static IEnumerable<XElement> GetParameters(this XElement? element) => element?.Elements("param") ?? [];

    public static string? GetNameAttribute(this XElement element) => element.Attribute("name")?.Value;
}
