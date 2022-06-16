using System;
using System.IO;
using System.Xml.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Markdown.Internal;

namespace DefaultDocumentation.Markdown.Elements
{
    /// <summary>
    /// Handles <c>code</c> xml element.
    /// </summary>
    public sealed class CodeElement : IElement
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "code";

        private static string GetCode(ISettings settings, string source, string? region = null)
        {
            if (!Path.IsPathRooted(source) && settings.ProjectDirectory != null)
            {
                source = Path.Combine(settings.ProjectDirectory.FullName, source);
            }

            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"Unable to find code documentation file \"{source}\".");
            }

            string? code = File.ReadAllText(source);
            if (!string.IsNullOrEmpty(region))
            {
                code = CodeRegion.Extract(code, region!);
                if (code is null)
                {
                    throw new InvalidOperationException($"Unable to find region \"{region}\" in file \"{source}\".");
                }
            }

            // remove \r to be consistent with xml content
            return code.Replace("\r", string.Empty);
        }

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer, XElement element)
        {
            if (writer.GetDisplayAsSingleLine())
            {
                return;
            }

            string? source = element.GetSourceAttribute();

            writer
                .EnsureLineStartAndAppendLine()
                .Append("```")
                .AppendLine(element.GetLanguageAttribute() ?? "csharp")
                .Append(source is null ? element : new XElement("code", GetCode(writer.Context.Settings, source, element.GetRegionAttribute())))
                .TrimEnd(Environment.NewLine, " ")
                .AppendLine()
                .Append("```");
        }
    }
}
