using System;
using System.IO;
using System.Xml.Linq;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation.Markdown.Elements
{
    public sealed class CodeWriter : IElementWriter
    {
        private static string GetCode(Settings settings, string source, string region = null)
        {
            if (!Path.IsPathRooted(source) && settings.ProjectDirectory != null)
            {
                source = Path.Combine(settings.ProjectDirectory.FullName, source);
            }

            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"Unable to find code documentation file \"{source}\".");
            }

            string code = File.ReadAllText(source);
            if (!string.IsNullOrEmpty(region))
            {
                code = CodeRegion.Extract(code, region);
                if (code is null)
                {
                    throw new InvalidOperationException($"Unable to find region \"{region}\" in file \"{source}\".");
                }
            }

            // remove \r to be consistent with xml content
            return code.Replace("\r", string.Empty);
        }

        public string Name => "code";

        public void Write(PageWriter writer, XElement element)
        {
            if (writer.DisplayAsSingleLine)
            {
                return;
            }

            using IDisposable _ = writer.ChangeIgnoreLineBreak(true);

            writer
                .EnsureLineStart()
                .Append("```")
                .AppendLine(element.GetLanguageAttribute() ?? "csharp");

            string source = element.GetSourceAttribute();

            if (source is null)
            {
                writer.AppendMultiline(element.Value);
            }
            else
            {
                writer
                    .With(writer.CurrentItem)
                    .AppendMultiline(GetCode(writer.Context.Settings, source, element.GetRegionAttribute()));
            }

            writer
                .EnsureLineStart()
                .AppendLine("```");
        }
    }
}
