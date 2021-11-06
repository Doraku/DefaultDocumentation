namespace DefaultDocumentation.Models
{
    public sealed class ExternDocItem : DocItem
    {
        public string Url { get; }

        public ExternDocItem(string id, string url, string name)
            : base(null, id, id.Substring(2), name, null)
        {
            Url = url;
        }
    }
}
