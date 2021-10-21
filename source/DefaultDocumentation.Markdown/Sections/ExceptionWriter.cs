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
            foreach (XElement exception in writer.CurrentItem.Documentation.GetExceptions())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStart()
                        .AppendLine("#### Exceptions");
                }

                string cref = exception.GetCRefAttribute();

                writer
                    .EnsureLineStart()
                    .AppendLine()
                    .AppendLink(cref)
                    .AppendLine()
                    .AppendAsMarkdown(exception);
            }
        }
    }
}
