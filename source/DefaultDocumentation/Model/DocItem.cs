using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class DocItem
    {
        public DocItem Parent { get; }
        public string Id { get; }
        public XElement Documentation { get; }
        public string Link { get; }
        public string Name { get; }
        public string FullName { get; }

        protected DocItem(DocItem parent, string id, XElement documentation)
        {
            Parent = parent;
            Id = id;
            Documentation = documentation;
            Link = Id.Clean();

            // Name
            // FullName
        }

        protected DocItem(DocItem parent, IEntity entity, XElement documentation)
            : this(parent, entity.GetIdString(), documentation)
        { }

        public string GetLinkTarget() => $"<a name='{Link}'></a>";

        public string GetLink(bool useFullName = true)
        {
            string displayedName = useFullName ? FullName : Name;

            return $"[{displayedName}](./{Link}.md '{FullName}')";
        }

        public string GetLinkTarget(bool isOnPage) => $"[{Name}]({(isOnPage ? string.Empty : $"{Parent.Link}.md")}#{Link} '{FullName}')";

        public abstract void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items);
    }
}
