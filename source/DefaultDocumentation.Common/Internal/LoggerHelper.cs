using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DefaultDocumentation.Models;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal;

internal static partial class LoggerHelper
{
    [LoggerMessage(LogLevel.Information, "starting DefaultDocumentation {Version} with this configuration:\n{Configuration}")]
    private static partial void LogStartingWithConfiguration(ILogger logger, Version version, string configuration);

    public static void LogStarting(ILogger logger, JObject configuration)
        => LogStartingWithConfiguration(logger, typeof(LoggerHelper).Assembly.GetName().Version, configuration.ToString(Formatting.Indented));

    [LoggerMessage(LogLevel.Information, "starting DefaultDocumentation with those settings:\n{Settings}")]
    private static partial void LogStartingWithSettings(ILogger logger, string settings);

    public static void LogStarting(ILogger logger, Settings settings)
        => LogStartingWithSettings(
            logger,
            @$"Starting DefaultDocumentation with those settings:
  - {nameof(settings.AssemblyFile)}: {settings.AssemblyFile}
  - {nameof(settings.DocumentationFile)}: {settings.DocumentationFile}
  - {nameof(settings.ProjectDirectory)}: {settings.ProjectDirectory}
  - {nameof(settings.OutputDirectory)}: {settings.OutputDirectory}
  - {nameof(settings.AssemblyPageName)}: {settings.AssemblyPageName}
  - {nameof(settings.GeneratedAccessModifiers)}: {settings.GeneratedAccessModifiers}
  - {nameof(settings.GeneratedPages)}: {settings.GeneratedPages}
  - {nameof(settings.IncludeUndocumentedItems)}: {settings.IncludeUndocumentedItems}
  - {nameof(settings.LinksOutputFile)}: {settings.LinksOutputFile}
  - {nameof(settings.LinksBaseUrl)}: {settings.LinksBaseUrl}
  - {nameof(settings.ExternLinksFiles)}:{string.Concat(settings.ExternLinksFiles.Select(file => $"\n    - {file.FullName}"))}");

    [LoggerMessage(LogLevel.Information, "using {AssemblyName} version {LoadedVersion} instead of version {ExpectedVersion}, may cause issue")]
    private static partial void LogAssemblyDifferentVersionAsInformation(ILogger logger, string assemblyName, Version loadedVersion, Version expectedVersion);

    public static void LogAssemblyDifferentVersionAsInformation(ILogger logger, AssemblyName loadedAssembly, AssemblyName expectedAssembly)
        => LogAssemblyDifferentVersionAsInformation(logger, loadedAssembly.Name, loadedAssembly.Version, expectedAssembly.Version);

    [LoggerMessage(LogLevel.Warning, "using {AssemblyName} version {LoadedVersion} instead of version {ExpectedVersion}, may cause issue")]
    private static partial void LogAssemblyDifferentVersionAsWarning(ILogger logger, string assemblyName, Version loadedVersion, Version expectedVersion);

    public static void LogAssemblyDifferentVersionAsWarning(ILogger logger, AssemblyName loadedAssembly, AssemblyName expectedAssembly)
        => LogAssemblyDifferentVersionAsWarning(logger, loadedAssembly.Name, loadedAssembly.Version, expectedAssembly.Version);

    [LoggerMessage(LogLevel.Information, "{ItemKind} that will be used:\n{Items}")]
    private static partial void LogUsedItems(ILogger logger, string itemKind, string items);

    public static void LogUsedItems(ILogger logger, string itemKind, IEnumerable<string>? items)
        => LogUsedItems(logger, itemKind, string.Join("\n", (items ?? []).Select(item => "  - " + item)));

    [LoggerMessage(LogLevel.Trace, "writing DocItem \"{DocItem}\" with id \"{DocItemId}\"")]
    private static partial void LogWritingDocItem(ILogger logger, DocItem docItem, string docItemId);

    public static void LogWritingDocItem(ILogger logger, DocItem docItem)
        => LogWritingDocItem(logger, docItem, docItem.Id);

    [LoggerMessage(LogLevel.Debug, "writing links to file \"{LinksOutputFile}\"")]
    public static partial void LogWritingLinksFile(ILogger logger, FileInfo linksOutputFile);

    [LoggerMessage(LogLevel.Debug, "documentation generated to output folder \"{OutputDirectory}\"")]
    public static partial void LogDocumentationGenerated(ILogger logger, DirectoryInfo outputDirectory);

    [LoggerMessage(LogLevel.Warning, "An other instance of DefaultDocumentation is trying to generate a documentation to the same output directory \"{OutputDirectory}\", the current one will stop")]
    public static partial void LogDocumentationAlreadyGenerating(ILogger logger, DirectoryInfo outputDirectory);

    [LoggerMessage(LogLevel.Trace, "looking for documentation of \"{Entity}\"")]
    public static partial void LogSearchingDocumentation(ILogger logger, IEntity? entity);

    [LoggerMessage(LogLevel.Trace, "looking for documentation of \"{EntityId}\"")]
    public static partial void LogSearchingDocumentation(ILogger logger, string entityId);

    [LoggerMessage(LogLevel.Trace, "loading documentation provider for \"{AssemblyFile}\"")]
    private static partial void LogLoadingDocumentationProvider(ILogger logger, string assemblyFile);

    public static void LogLoadingDocumentationProvider(ILogger logger, PEFile file)
        => LogLoadingDocumentationProvider(logger, file.FullName);

    [LoggerMessage(LogLevel.Trace, "looking for inherited documentation of \"{Entity}\"")]
    public static partial void LogSearchingInheritedDocumentation(ILogger logger, IEntity entity);

    [LoggerMessage(LogLevel.Trace, "looking for inherited documentation of \"{Entity}\" cref \"{DocumentationReference}\"")]
    public static partial void LogSearchingInheritedDocumentation(ILogger logger, IEntity entity, string documentationReference);

    [LoggerMessage(LogLevel.Warning, "cyclic inherited documentation detected for cref \"{DocumentationReference}\", handled as no documentation available")]
    public static partial void LogCyclicInheritedDocumentation(ILogger logger, string documentationReference);

    [LoggerMessage(LogLevel.Trace, "handling entity \"{Entity}\"")]
    public static partial void LogHandlingEntity(ILogger logger, IEntity entity);

    [LoggerMessage(LogLevel.Trace, "skipping documentation for entity \"{Entity}\": {SkipReason}")]
    public static partial void LogSkippingEntity(ILogger logger, IEntity entity, string skipReason);

    [LoggerMessage(LogLevel.Trace, "adding DocItem \"{DocItem}\" with id \"{DocItemId}\"")]
    private static partial void LogAddingDocItem(ILogger logger, DocItem docItem, string docItemId);

    public static void LogAddingDocItem(ILogger logger, DocItem docItem)
        => LogAddingDocItem(logger, docItem, docItem.Id);

    [LoggerMessage(LogLevel.Warning, "duplicate DocItem \"{DocItem}\" with id \"{DocItemId}\" ignored")]
    private static partial void LogDuplicateDocItem(ILogger logger, DocItem docItem, string docItemId);

    public static void LogDuplicateDocItem(ILogger logger, DocItem docItem)
        => LogDuplicateDocItem(logger, docItem, docItem.Id);
}
