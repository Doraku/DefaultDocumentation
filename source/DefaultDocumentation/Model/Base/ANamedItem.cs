using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class ANamedItem : AItem
    {
        public string Name { get; }
        public string Namespace { get; }
        public virtual string FullName => $"{Namespace}.{Name}";
        public string LinkName { get; }

        protected ANamedItem(AMemberItem parent, string name, XElement element)
            : base(parent, element)
        {
            Name = name;
            Namespace = Parent?.FullName ?? Element.GetNamespace();
            LinkName = FullName.CleanForLink();
        }

        protected ANamedItem(AMemberItem parent, XElement element)
            : this(parent, element.GetName(), element)
        { }
    }
}
