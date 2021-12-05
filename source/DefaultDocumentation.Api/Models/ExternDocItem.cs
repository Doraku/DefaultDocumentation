using System;

namespace DefaultDocumentation.Models
{
    /// <summary>
    /// Represent an external documentation.
    /// </summary>
    public sealed class ExternDocItem : DocItem
    {
        /// <summary>
        /// Gets the url of the current instance.
        /// </summary>
        public string Url { get; }

        internal ExternDocItem(string id, string url, string name)
            : base(null, id, id.Substring(2), name ?? id.Substring(2), null)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}
