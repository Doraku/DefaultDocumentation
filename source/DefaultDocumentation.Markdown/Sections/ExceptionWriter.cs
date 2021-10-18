using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExceptionWriter : ISectionWriter
    {
        public string Name => "exception";

        public void Write(PageWriter writer)
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
                    .AppendLink(cref)
                    .AppendLine()
                    .Append(exception)
                    .AppendLine();
            }
        }
    }
}
