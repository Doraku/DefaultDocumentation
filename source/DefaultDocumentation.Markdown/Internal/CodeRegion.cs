using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DefaultDocumentation.Markdown.Internal
{
    internal static class CodeRegion
    {
        private static readonly Regex _regionStartRegex = new("\r*^ *#region ", RegexOptions.Multiline);
        private static readonly Regex _regionEndRegex = new("\r*^ *#endregion", RegexOptions.Multiline);
        private static readonly Regex _commentStartRegex = new("/\\*", RegexOptions.Multiline);
        private static readonly Regex _commentEndRegex = new("\\*/", RegexOptions.Multiline);

        private static IEnumerable<(int, int)> GetComments(string fileContent)
        {
            Match commentStart = _commentStartRegex.Match(fileContent);

            while (commentStart.Success)
            {
                Match commentEnd = _commentEndRegex.Match(fileContent, commentStart.Index + 2);

                if (!commentEnd.Success)
                {
                    yield return (commentStart.Index, fileContent.Length);
                    yield break;
                }

                yield return (commentStart.Index, commentEnd.Index);
                commentStart = _commentStartRegex.Match(fileContent, commentEnd.Index + 2);
            }
        }

        public static string? Extract(string fileContent, string region)
        {
            (int start, int end)[] comments = GetComments(fileContent).ToArray();

            bool IsInComments(int i) => comments.Any(c => i > c.start && i < c.end);

            Match regionStart = Match.Empty;
            Regex regionRegex = new($"\r*^ *#region *{region.Trim()} *\r*$", RegexOptions.Multiline);

            do
            {
                regionStart = regionRegex.Match(fileContent, regionStart.Index + regionStart.Length);
            }
            while (regionStart.Success && IsInComments(regionStart.Index));

            if (!regionStart.Success)
            {
                return null;
            }

            int regionStartIndex = regionStart.Index + regionStart.Value.Length + 1;

            IEnumerable<Match> allRegionStarts = _regionStartRegex.Matches(fileContent, regionStartIndex).OfType<Match>().Where(m => m.Success && !IsInComments(m.Index));

            int innerRegionCount = 0;

            foreach (Match regionEnd in _regionEndRegex.Matches(fileContent, regionStartIndex).OfType<Match>().Where(m => m.Success && !IsInComments(m.Index)))
            {
                if (innerRegionCount == allRegionStarts.Count(m => m.Index < regionEnd.Index))
                {
                    return fileContent.Substring(regionStartIndex, regionEnd.Index - regionStartIndex);
                }

                ++innerRegionCount;
            }

            return null;
        }
    }
}
