using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Model
{
    internal sealed class ParameterDocItem : DocItem
    {
        public IParameter Parameter { get; }

        public ParameterDocItem(DocItem parent, IParameter entity, XElement documentation)
            : base(parent, entity.Name, entity.Name, $"{parent.FullName}.{entity.Name}", documentation.GetParameters()?.FirstOrDefault(d => d.GetName() == entity.Name))
        {
            Parameter = entity;
        }

        public override void WriteDocumentation(DocumentationWriter writer, IReadOnlyDictionary<string, DocItem> items)
        {
            writer.Write($"{writer.GetLinkTarget(this)} {writer.GetTypeLink(this, Parameter.Type)}  ");
            writer.Write(this, Documentation);
        }
    }
}
