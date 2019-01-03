using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Model;

namespace DefaultDocumentation.Helper
{
    internal static class XElementExtension
    {
        public static XElement GetSummary(this XElement element) => element?.Element("summary");

        public static IEnumerable<XElement> GetGenerics(this XElement element) => element.Elements("typeparam");

        public static IEnumerable<XElement> GetParameters(this XElement element) => element.Elements("param");

        public static IEnumerable<XElement> GetExceptions(this XElement element) => element?.Elements("exception");

        public static XElement GetReturns(this XElement element) => element.Element("returns");

        public static XElement GetRemarks(this XElement element) => element?.Element("remarks");

        public static XElement GetExample(this XElement element) => element.Element("example");

        public static string GetFullName(this XElement element) => element?.Attribute("name")?.Value;

        public static string GetName(this XElement element) => element.GetFullName()?.Split('.').Last();

        public static string GetNamespace(this XElement element)
        {
            string name = element.GetFullName();
            if (name != null
                && (name.StartsWith(MethodItem.Id) || name.StartsWith(PropertyItem.Id))
                && name.IndexOf('(') >= 0)
            {
                name = name.Substring(0, name.IndexOf('('));
            }

            return name?.Substring(2, name.LastIndexOf('.') - 2);
        }

        public static string GetReferenceName(this XElement element) => element.Attribute("cref").Value;
    }
}
