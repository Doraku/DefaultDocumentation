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
            : base(parent, entity.Name, $"{parent.FullName}.{entity.Name}", entity.Name, documentation.GetParameters()?.FirstOrDefault(d => d.GetName() == entity.Name))
        {
            Parameter = entity;
        }

        public override bool GeneratePage => false;

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteLinkTarget(this);
            writer.WriteLine($"`{Parameter.Name}` {writer.GetTypeLink(Parameter.Type)}  ");
            writer.Write(this, Documentation);
        }
    }
}
