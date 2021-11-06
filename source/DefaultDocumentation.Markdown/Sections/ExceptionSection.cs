using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class ExceptionSection : ISection
    {
        public string Name => "exception";

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (XElement exception in writer.GetCurrentItem().Documentation?.Elements(Name) ?? Enumerable.Empty<XElement>())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStartAndAppendLine()
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
