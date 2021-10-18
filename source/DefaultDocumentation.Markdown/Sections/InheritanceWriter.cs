using System.Linq;
using DefaultDocumentation.Model.Type;
using DefaultDocumentation.Writer;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class InheritanceWriter : ISectionWriter
    {
        public string Name => "inheritance";

        public void Write(PageWriter writer)
        {
            if (writer.CurrentItem is TypeDocItem typeItem && typeItem.Type.Kind == TypeKind.Class)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .Append("Inheritance ");

                foreach (IType t in typeItem.Type.GetNonInterfaceBaseTypes().Where(t => t != typeItem.Type))
                {
                    writer
                        .AppendLink(typeItem, t)
                        .Append(" &#129106; ");
                }

                writer.AppendLine(typeItem.Name);
            }
        }
    }
}
