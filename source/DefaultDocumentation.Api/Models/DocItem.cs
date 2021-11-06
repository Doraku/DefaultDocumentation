using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Models
{
    public abstract class DocItem
    {
        public DocItem Parent { get; }

        public string Id { get; }

        public string FullName { get; }

        public string Name { get; }

        public XElement Documentation { get; }

        private protected DocItem(DocItem parent, string id, string fullName, string name, XElement documentation)
        {
            Parent = parent;
            Id = id ?? throw new ArgumentNullException(nameof(id));
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Documentation = documentation;
        }
    }
}
