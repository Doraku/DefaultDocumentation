using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DefaultDocumentation.Helper
{
    internal static class XElementExtension
    {
        public static XElement GetSummary(this XElement element) => element?.Element("summary");

        public static IEnumerable<XElement> GetTypeParameters(this XElement element) => element?.Elements("typeparam");

        public static IEnumerable<XElement> GetParameters(this XElement element) => element?.Elements("param");

        public static IEnumerable<XElement> GetExceptions(this XElement element) => element?.Elements("exception");

        public static XElement GetReturns(this XElement element) => element?.Element("returns");

        public static XElement GetRemarks(this XElement element) => element?.Element("remarks");

        public static XElement GetExample(this XElement element) => element?.Element("example");

        public static XElement GetValue(this XElement element) => element?.Element("value");

        public static string GetName(this XElement element) => element.Attribute("name")?.Value;

        public static string GetReferenceName(this XElement element) => element.Attribute("cref")?.Value;

        public static string GetLangWord(this XElement element) => element.Attribute("langword")?.Value;

        public static string GetCodeSource(this XElement element) => element.Attribute("source")?.Value;
        public static string GetCodeRegion(this XElement element) => element.Attribute("region")?.Value;

        public static bool HasExclude(this XElement element) => element.Descendants("exclude").Any();

        public static bool HasInheritDoc(this XElement element, out XElement inheritDoc)
        {
            inheritDoc = element?.Descendants("inheritdoc").FirstOrDefault();
            return inheritDoc != null;
        }
    }
}
