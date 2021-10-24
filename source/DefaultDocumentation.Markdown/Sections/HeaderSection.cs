using System.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class HeaderSection : ISectionWriter
    {
        public string Name => "Header";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() != writer.DocItem)
            {
                return;
            }

            AssemblyDocItem assembly = writer.Context.Items.OfType<AssemblyDocItem>().Single();
            if (writer.Context.HasOwnPage(assembly))
            {
                writer
                    .EnsureLineStart()
                    .Append("#### ")
                    .AppendLink(assembly)
                    .AppendLine();
            }

            writer.EnsureLineStart();

            bool firstWritten = false;
            foreach (DocItem parent in writer.DocItem.GetParents().Skip(1))
            {
                if (!firstWritten)
                {
                    writer.Append("### ");
                    firstWritten = true;
                }
                else
                {
                    writer.Append(".");
                }

                writer.AppendLink(parent);
            }
        }
    }
}
