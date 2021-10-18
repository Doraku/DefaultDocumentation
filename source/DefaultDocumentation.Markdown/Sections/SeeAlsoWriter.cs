using System;
using System.Xml.Linq;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SeeAlsoWriter : SectionWriter
    {
        public SeeAlsoWriter()
            : base("seealso")
        { }

        public override void Write(PageWriter writer)
        {
            bool titleWritten = false;
            foreach (XElement seeAlso in writer.CurrentItem.Documentation.GetSeeAlsos())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStart()
                        .AppendLine("#### See Also");
                }

                string @ref = seeAlso.GetCRefAttribute();
                if (@ref is not null)
                {
                    writer
                        .Append("- ")
                        .AppendLink(@ref, seeAlso.Value.NullIfEmpty())
                        .AppendLine();

                    continue;
                }

                @ref = seeAlso.GetHRefAttribute();
                if (@ref is not null)
                {
                    writer
                        .Append("- ")
                        .AppendLink(@ref, seeAlso.Value.NullIfEmpty())
                        .AppendLine();
                }
            }
        }
    }
}
