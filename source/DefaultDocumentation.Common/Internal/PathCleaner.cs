using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DefaultDocumentation.Internal
{
    internal sealed class PathCleaner
    {
        private readonly Dictionary<string, string> _invalidStrings;

        public string InvalidCharReplacement { get; }

        public PathCleaner(string invalidCharReplacement)
        {
            InvalidCharReplacement = invalidCharReplacement;

            _invalidStrings = new Dictionary<string, string>(Path.GetInvalidFileNameChars().ToDictionary(c => $"{c}", _ => invalidCharReplacement))
            {
                ["="] = string.Empty,
                [" "] = string.Empty,
                [","] = invalidCharReplacement,
                ["."] = invalidCharReplacement,
                ["["] = invalidCharReplacement,
                ["]"] = invalidCharReplacement,
                ["&lt;"] = invalidCharReplacement,
                ["&gt;"] = invalidCharReplacement,
            };
        }

        public string Clean(string value)
        {
            foreach (KeyValuePair<string, string> pair in _invalidStrings)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
        }
    }
}
