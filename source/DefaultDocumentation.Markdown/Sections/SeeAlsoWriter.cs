using System;
using System.Xml.Linq;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SeeAlsoWriter : ISectionWriter
    {
        public string Name => "seealso";

        public void Write(IWriter writer)
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
