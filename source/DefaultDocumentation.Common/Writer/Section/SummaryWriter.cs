using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Parameter;

namespace DefaultDocumentation.Writer.Section
{
    internal sealed class SummaryWriter : SectionWriter
    {
        public SummaryWriter()
            : base("summary")
        { }

        public override void Write(PageWriter writer)
        {
            writer
                .EnsureLineStart()
                .Append(writer.CurrentItem switch
                {
                    TypeParameterDocItem => writer.CurrentItem.Documentation,
                    ParameterDocItem => writer.CurrentItem.Documentation,
                    _ => writer.CurrentItem.Documentation.GetSummary()
                })
                .EnsureLineStart();
        }
    }
}
