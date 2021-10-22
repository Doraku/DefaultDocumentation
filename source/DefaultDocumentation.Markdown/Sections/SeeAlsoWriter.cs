using System;
using System.Linq;
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
            foreach (XElement seeAlso in writer.CurrentItem.Documentation?.Elements(Name) ?? Enumerable.Empty<XElement>())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStart()
                        .AppendLine()
                        .Append("#### See Also");
                }

                string @ref = seeAlso.GetCRefAttribute();
                if (@ref is not null)
                {
                    writer
                        .AppendLine()
                        .Append("- ")
                        .AppendLink(@ref, seeAlso.Value.NullIfEmpty());

                    continue;
                }

                @ref = seeAlso.GetHRefAttribute();
                if (@ref is not null)
                {
                    writer
                        .AppendLine()
                        .Append("- ")
                        .AppendUrl(@ref, seeAlso.Value.NullIfEmpty());
                }
            }
        }
    }
}
