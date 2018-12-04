using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal static class DocItemExtension
    {
        public static string FullName(this ADocItem item) => $"{item.Namespace}.{item.Name}";
    }

    internal abstract class ADocItem
    {
        public ADocItem Parent { get; }
        public string Namespace { get; }
        public string Name { get; }
        public XElement Summary { get; }
        public ExceptionItem[] Exceptions { get; }

        protected ADocItem(string @namespace, string name, XElement item)
        {
            Parent = null;
            Namespace = @namespace;
            Name = name;
            Summary = item.GetSummary() ?? item;
            Exceptions = item.GetExceptions().Select(i => new ExceptionItem(this, i)).ToArray();
        }

        protected ADocItem(ADocItem parent, string name, XElement item)
            : this(parent?.FullName() ?? item.GetNamespace(), name, item)
        {
            Parent = parent;
        }

        protected ADocItem(ADocItem parent, XElement item)
            : this(parent, item.GetName(), item)
        { }
    }
}
