using System.Text;

namespace DefaultDocumentation.Helper
{
    internal static class StringBuilderExtension
    {
        public static StringBuilder AppendPrefixedLine(this StringBuilder builder, string prefix) =>
            builder.AppendLine().Append(prefix);
        public static StringBuilder AppendPrefixedLine(this StringBuilder builder, string text, string prefix) =>
            builder.AppendLine(text).Append(prefix);
    }
}