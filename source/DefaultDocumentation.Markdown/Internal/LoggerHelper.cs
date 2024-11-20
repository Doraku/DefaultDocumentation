using System.IO;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation.Markdown.Internal;

internal static partial class LoggerHelper
{
    [LoggerMessage(LogLevel.Debug, "Cleaning output folder \"{OutputDirectory}\"")]
    public static partial void LogCleaning(ILogger logger, DirectoryInfo outputDirectory);
}
