using System.Collections.Generic;
using System.Xml.Linq;

namespace DefaultDocumentation.Helper
{
    internal static class XDocumentExtension
    {
        public static IEnumerable<XElement> GetMembers(this XDocument document) => document.Descendants("member");
    }
}
