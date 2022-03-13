using System.IO;
using System.Linq;

namespace DefaultDocumentation.Markdown.Internal
{
    internal static class PathCleaner
    {
        private static readonly string[] toTrimChars = new[] { '=', ' ' }.Select(c => $"{c}").ToArray();
        private static readonly string[] invalidChars = new[] { '\"', '<', '>', ':', '*', '?' }.Concat(Path.GetInvalidPathChars()).Select(c => $"{c}").ToArray();

        public static string Clean(string value, string invalidCharReplacement)
        {
            foreach (string toTrimChar in toTrimChars)
            {
                value = value.Replace(toTrimChar, string.Empty);
            }

            invalidCharReplacement = string.IsNullOrEmpty(invalidCharReplacement) ? "_" : invalidCharReplacement;

            foreach (string invalidChar in invalidChars)
            {
                value = value.Replace(invalidChar, invalidCharReplacement);
            }

            return value.Trim('/');
        }
    }
}
