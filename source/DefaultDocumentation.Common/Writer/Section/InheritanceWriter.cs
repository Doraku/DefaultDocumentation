using System.Linq;
using DefaultDocumentation.Model.Type;
using ICSharpCode.Decompiler.TypeSystem;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class InheritanceWriter : SectionWriter
    {
        public InheritanceWriter()
            : base("inheritance")
        { }

        public override void Write(PageWriter writer)
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
