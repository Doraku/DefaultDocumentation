using System.Diagnostics.CodeAnalysis;

namespace System.Xml.Linq
{
    internal static class XElementExtensions
    {
        public static string? GetCRefAttribute(this XElement element) => element.Attribute("cref")?.Value;

        public static bool HasExclude(this XElement? element) => element?.Element("exclude") != null;

        public static bool HasInheritDoc(this XElement? element, [NotNullWhen(true)] out XElement? inheritDoc)
        {
            inheritDoc = element?.Element("inheritdoc");

            return inheritDoc != null;
        }
    }
}
