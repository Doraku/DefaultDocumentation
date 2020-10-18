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
            : base(parent, entity.Name, $"{parent.FullName}.{entity.Name}", entity.Name, documentation.GetTypeParameters()?.FirstOrDefault(d => d.GetName() == entity.Name))
        {
            TypeParameter = entity;
        }

        public override bool GeneratePage => false;

        public override void WriteDocumentation(DocumentationWriter writer)
        {
            writer.WriteLinkTarget(this);
            writer.WriteLine($"`{TypeParameter.Name}`  ");
            writer.Write(this, Documentation);

            if (TypeParameter.TypeConstraints.Any(c => !c.Type.IsObjectOrValueType()))
            {
                writer.Break();

                writer.Write("Constraints ");
                writer.Write(string.Join(", ", TypeParameter.TypeConstraints.Select(c => c.Type).Where(t => !t.IsObjectOrValueType()).Select(writer.GetTypeLink)));
                writer.WriteLine("  ");
            }
        }
    }
}
