using System.Collections.Generic;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.Documentation;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal abstract class DocItem
    {
        public string Id { get; }
        public XElement Documentation { get; }
        public string Link { get; }

        protected DocItem(IEntity entity, XElement documentation)
        {
            Id = entity.GetIdString();
            Documentation = documentation;
            Link = Id.Clean();
        }

        public virtual void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        { }
    }
}
