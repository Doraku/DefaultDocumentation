using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExceptionWriter : ISectionWriter
    {
        public string Name => "exception";

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (XElement exception in writer.CurrentItem.Documentation?.Elements(Name) ?? Enumerable.Empty<XElement>())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStart()
                        .AppendLine()
                        .Append("#### Exceptions");
                }

                string cref = exception.GetCRefAttribute();

                writer
                    .AppendLine()
                    .AppendLine()
                    .AppendLink(cref)
                    .AppendLine("  ")
                    .AppendAsMarkdown(exception);
            }
        }
    }
}
