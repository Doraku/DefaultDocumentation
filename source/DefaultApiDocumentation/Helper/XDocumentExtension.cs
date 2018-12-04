using System.Collections.Generic;
using System.Xml.Linq;

namespace DefaultApiDocumentation.Helper
{
    internal static class XDocumentExtension
    {
        public static IEnumerable<XElement> GetMembers(this XDocument document) => document.Descendants("member");
    }
}
