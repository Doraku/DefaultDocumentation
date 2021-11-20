using System.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class HeaderSection : ISection
    {
        public string Name => "Header";

        public void Write(IWriter writer)
        {
            if (writer.GetCurrentItem() != writer.DocItem)
            {
                return;
            }

            AssemblyDocItem assembly = writer.Context.Items.Values.OfType<AssemblyDocItem>().Single();
            if (assembly.HasOwnPage(writer.Context))
            {
                writer
                    .EnsureLineStart()
                    .Append("#### ")
                    .AppendLink(assembly);
            }

            bool firstWritten = false;
            foreach (DocItem parent in writer.DocItem.GetParents().Skip(1))
            {
                if (!firstWritten)
                {
                    firstWritten = true;
                    writer
                        .EnsureLineStart()
                        .Append("### ");
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
