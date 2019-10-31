using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class TypeParameterDocItem : DocItem
    {
        public ITypeParameter TypeParameter { get; }

        public TypeParameterDocItem(DocItem parent, ITypeParameter entity, XElement documentation)
            : base(parent, entity.Name, documentation.GetTypeParameters()?.FirstOrDefault(d => d.GetName() == entity.Name))
        {
            TypeParameter = entity;
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.WriteLine(GetLinkTarget());
            writer.WriteLine($"`{TypeParameter.Name}`  ");
            writer.Write(Documentation, this, items);
        }
    }
}
