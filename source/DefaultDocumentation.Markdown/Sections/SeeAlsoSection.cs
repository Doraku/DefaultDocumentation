using System;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Sections
{
    public sealed class SeeAlsoSection : ISection
    {
        public string Name => "seealso";

        public void Write(IWriter writer)
        {
            bool titleWritten = false;
            foreach (XElement seeAlso in writer.GetCurrentItem().Documentation?.Elements(Name) ?? Enumerable.Empty<XElement>())
            {
                if (!titleWritten)
                {
                    titleWritten = true;
                    writer
                        .EnsureLineStartAndAppendLine()
                        .Append("### See Also");
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
