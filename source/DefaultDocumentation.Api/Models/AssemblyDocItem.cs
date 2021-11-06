using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    public sealed class AssemblyDocItem : DocItem
    {
        public AssemblyDocItem(string fullName, string name, XElement documentation)
            : base(null, string.Empty, fullName, name, documentation)
        { }
    }
}
