using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class ExceptionWriter : SectionWriter
    {
        public ExceptionWriter()
            : base("exception")
        { }

        public override void Write(PageWriter writer)
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
