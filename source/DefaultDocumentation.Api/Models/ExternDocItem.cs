using System;

namespace DefaultDocumentation.Models
{
    public sealed class ExternDocItem : DocItem
    {
        public string Url { get; }

        public ExternDocItem(string id, string url, string name)
            : base(null, id, id.Substring(2), name ?? id.Substring(2), null)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}
