using System.Collections.Generic;

namespace System.Xml.Linq
{
    internal static class XElementExtension
    {
        public static IEnumerable<XElement> GetItems(this XElement element) => element.Elements("item");

        public static IEnumerable<XElement> GetDescriptions(this XElement element) => element.Elements("description");

        public static XElement GetSummary(this XElement element) => element?.Element("summary");

        public static XElement GetListHeader(this XElement element) => element.Element("listheader");

        public static string GetNameAttribute(this XElement element) => element.Attribute("name")?.Value;

        public static string GetCRefAttribute(this XElement element) => element.Attribute("cref")?.Value;

        public static string GetHRefAttribute(this XElement element) => element.Attribute("href")?.Value;

        public static string GetLangWordAttribute(this XElement element) => element.Attribute("langword")?.Value;

        public static string GetSourceAttribute(this XElement element) => element.Attribute("source")?.Value;

        public static string GetRegionAttribute(this XElement element) => element.Attribute("region")?.Value;

        public static string GetLanguageAttribute(this XElement element) => element.Attribute("language")?.Value;

        public static string GetTypeAttribute(this XElement element) => element.Attribute("type")?.Value;

        public static bool? GetIgnoreLineBreak(this XElement element) => bool.TryParse(element.Attribute("ignorelinebreak")?.Value, out bool ignoreLineBreak) ? ignoreLineBreak : null;
    }
}
