using System.Collections.Generic;
using System.Linq;

namespace System.Xml.Linq
{
    internal static class XElementExtension
    {
        public static IEnumerable<XElement> GetTypeParameters(this XElement? element) => element?.Elements("typeparam") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetParameters(this XElement? element) => element?.Elements("param") ?? Enumerable.Empty<XElement>();

        public static string? GetNameAttribute(this XElement element) => element.Attribute("name")?.Value;
    }
}
