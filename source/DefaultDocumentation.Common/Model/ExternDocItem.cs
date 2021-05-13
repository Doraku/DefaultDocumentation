using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Model
{
    internal sealed class ExternDocItem : DocItem
    {
        public override GeneratedPages Page => GeneratedPages.Default;

        public string Url { get; }

        public ExternDocItem(string id, string url, string name)
            : base(null, id, id.Substring(2), name ?? id.Substring(2).Prettify(), null)
        {
            Url = url;
        }
    }
}
