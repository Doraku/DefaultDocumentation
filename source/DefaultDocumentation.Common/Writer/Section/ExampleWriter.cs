using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class ExampleWriter : SectionWriter
    {
        public ExampleWriter()
            : base("example")
        { }

        public override void Write(PageWriter writer)
        {
            XElement example = writer.CurrentItem.Documentation.GetExample();

            if (example != null)
            {
                writer
                    .EnsureLineStart()
                    .AppendLine("### Example")
                    .Append(example)
                    .AppendLine();
            }
        }
    }
}
