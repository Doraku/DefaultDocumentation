using System.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models.Types;
using DefaultDocumentation.Api;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class InheritanceSection : ISection
    {
        public string Name => "Inheritance";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() is TypeDocItem typeItem && typeItem.Type.Kind == TypeKind.Class)
            {
                writer
                    .EnsureLineStartAndAppendLine()
                    .Append("Inheritance ");

                foreach (IType t in typeItem.Type.GetNonInterfaceBaseTypes().Where(t => t != typeItem.Type))
                {
                    writer
                        .AppendLink(typeItem, t)
                        .Append(" &#129106; ");
                }

                writer.Append(typeItem.Name);
            }
        }
    }
}
