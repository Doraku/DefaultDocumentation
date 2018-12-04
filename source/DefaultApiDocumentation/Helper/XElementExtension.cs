using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultApiDocumentation.Model;

namespace DefaultApiDocumentation.Helper
{
    internal static class XElementExtension
    {
        public static XElement GetSummary(this XElement item) => item.Element("summary");

        public static IEnumerable<XElement> GetGenerics(this XElement item) => item.Elements("typeparam");

        public static IEnumerable<XElement> GetParameters(this XElement item) => item.Elements("param");

        public static IEnumerable<XElement> GetExceptions(this XElement item) => item.Elements("exception");

        public static XElement GetReturns(this XElement item) => item.Element("returns");

        public static string GetFullName(this XElement item) => item.Attribute("name")?.Value;

        public static string GetName(this XElement item) => item.GetFullName()?.Split('.').Last();

        public static string GetNamespace(this XElement item)
        {
            string name = item.GetFullName();
            if (name.StartsWith(MethodItem.Id)
                && name.IndexOf('(') >= 0)
            {
                name = name.Substring(0, name.IndexOf('('));
            }

            return name.Substring(2, name.LastIndexOf('.') - 2);
        }

        public static string GetReferenceName(this XElement item) => item.Attribute("cref").Value;
    }
}
