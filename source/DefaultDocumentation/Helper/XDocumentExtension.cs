using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DefaultDocumentation.Helper
{
    internal static class XDocumentExtension
    {
        public static string GetAssemblyName(this XDocument document)
            => document.Descendants("assembly").Single().Element("name").Value;

        public static IEnumerable<XElement> GetMembers(this XDocument document) => document.Descendants("member");
    }
}
