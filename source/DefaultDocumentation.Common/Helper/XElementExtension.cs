using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DefaultDocumentation.Helper
{
    internal static class XElementExtension
    {
        public static XElement GetSummary(this XElement element) => element?.Element("summary");

        public static IEnumerable<XElement> GetTypeParameters(this XElement element) => element?.Elements("typeparam") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetParameters(this XElement element) => element?.Elements("param") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetExceptions(this XElement element) => element?.Elements("exception") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetSeeAlsos(this XElement element) => element?.Descendants("seealso") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetItems(this XElement element) => element?.Descendants("item") ?? Enumerable.Empty<XElement>();

        public static IEnumerable<XElement> GetDescriptions(this XElement element) => element?.Descendants("description") ?? Enumerable.Empty<XElement>();

        public static XElement GetReturns(this XElement element) => element?.Element("returns");

        public static XElement GetRemarks(this XElement element) => element?.Element("remarks");

        public static XElement GetExample(this XElement element) => element?.Element("example");

        public static XElement GetValue(this XElement element) => element?.Element("value");

        public static XElement GetListHeader(this XElement element) => element?.Element("listheader");

        public static string GetNameAttribute(this XElement element) => element.Attribute("name")?.Value;

        public static string GetCRefAttribute(this XElement element) => element.Attribute("cref")?.Value;

        public static string GetHRefAttribute(this XElement element) => element.Attribute("href")?.Value;

        public static string GetLangWordAttribute(this XElement element) => element.Attribute("langword")?.Value;

        public static string GetSourceAttribute(this XElement element) => element.Attribute("source")?.Value;

        public static string GetRegionAttribute(this XElement element) => element.Attribute("region")?.Value;

        public static string GetLanguageAttribute(this XElement element) => element.Attribute("language")?.Value;

        public static string GetTypeAttribute(this XElement element) => element.Attribute("type")?.Value;

        public static bool? GetIgnoreLineBreak(this XElement element) => bool.TryParse(element.Attribute("ignorelinebreak")?.Value, out bool ignoreLineBreak) ? ignoreLineBreak : null;

        public static bool HasExclude(this XElement element) => element?.Descendants("exclude").Any() ?? false;

        public static bool HasInheritDoc(this XElement element, out XElement inheritDoc)
        {
            inheritDoc = element?.Descendants("inheritdoc").FirstOrDefault();
            return inheritDoc != null;
        }
    }
}
