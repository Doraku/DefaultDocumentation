﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DefaultDocumentation.Internal;

public sealed class Settings : ISettings
{
    private const GeneratedPages _defaultGeneratedPages = GeneratedPages.Namespaces | GeneratedPages.Types | GeneratedPages.Members;
    private const GeneratedAccessModifiers _defaultGeneratedAccessModifiers = GeneratedAccessModifiers.Public | GeneratedAccessModifiers.Private | GeneratedAccessModifiers.Protected | GeneratedAccessModifiers.Internal | GeneratedAccessModifiers.ProtectedInternal | GeneratedAccessModifiers.PrivateProtected;

    private static readonly char[] _patternChars = ['*', '?'];
    private static readonly char[] _folderChars = ['/', '\\'];

    public Settings(
        ILogger logger,
        string? assemblyFilePath,
        string? documentationFilePath,
        string? projectDirectoryPath,
        string? outputDirectoryPath,
        string? assemblyPageName,
        GeneratedAccessModifiers generatedAccessModifiers,
        GeneratedPages generatedPages,
        bool includeUndocumentedItems,
        string? linksOutputFile,
        string? linksBaseUrl,
        IEnumerable<string>? externlinksFilePaths)
    {
        logger.ThrowIfNull();

        Logger = logger;

        AssemblyFile = !string.IsNullOrEmpty(assemblyFilePath) ? new FileInfo(assemblyFilePath) : throw new ArgumentException("assembly path cannot be null or empty", nameof(assemblyFilePath));
        DocumentationFile = string.IsNullOrEmpty(documentationFilePath) ? new FileInfo(Path.Combine(AssemblyFile.Directory.FullName, Path.GetFileNameWithoutExtension(AssemblyFile.Name) + ".xml")) : new FileInfo(documentationFilePath);
        ProjectDirectory = string.IsNullOrEmpty(projectDirectoryPath) ? null : new DirectoryInfo(projectDirectoryPath);
        OutputDirectory = string.IsNullOrEmpty(outputDirectoryPath) ? DocumentationFile.Directory : new DirectoryInfo(outputDirectoryPath);
        AssemblyPageName = assemblyPageName;
        GeneratedAccessModifiers = generatedAccessModifiers == GeneratedAccessModifiers.Default ? _defaultGeneratedAccessModifiers : generatedAccessModifiers;
        GeneratedPages = generatedPages == GeneratedPages.Default ? _defaultGeneratedPages : generatedPages;
        IncludeUndocumentedItems = includeUndocumentedItems;
        LinksOutputFile = string.IsNullOrEmpty(linksOutputFile) ? null : new FileInfo(linksOutputFile);
        LinksBaseUrl = linksBaseUrl ?? string.Empty;
        ExternLinksFiles = [.. (externlinksFilePaths ?? []).SelectMany(GetFilePaths).Distinct().Select(filePath => new FileInfo(filePath)).Where(file => file.Exists && file.FullName != LinksOutputFile?.FullName)];
    }

    private static IEnumerable<string> GetFilePaths(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            yield break;
        }

        if (filePath.IndexOfAny(_patternChars) < 0)
        {
            yield return filePath;
            yield break;
        }

        int folderIndex = filePath.LastIndexOfAny(_folderChars) + 1;

        foreach (string file in Directory.EnumerateFiles(filePath[..folderIndex], filePath[folderIndex..]))
        {
            yield return file;
        }
    }

    public void Validate()
    {
        if (!AssemblyFile.Exists)
        {
            throw new FileNotFoundException("The assembly file does not exist", AssemblyFile.FullName);
        }

        if (!DocumentationFile.Exists)
        {
            throw new FileNotFoundException("The xml documentation file does not exist, ensure you activated the \"GenerateDocumentationFile\" property of the project", DocumentationFile.FullName);
        }
    }

    #region ISettings

    public ILogger Logger { get; }

    public FileInfo AssemblyFile { get; }

    public FileInfo DocumentationFile { get; }

    public DirectoryInfo? ProjectDirectory { get; }

    public DirectoryInfo OutputDirectory { get; }

    public string? AssemblyPageName { get; }

    public GeneratedPages GeneratedPages { get; }

    public GeneratedAccessModifiers GeneratedAccessModifiers { get; }

    public bool IncludeUndocumentedItems { get; }

    public FileInfo? LinksOutputFile { get; }

    public string LinksBaseUrl { get; }

    public IEnumerable<FileInfo> ExternLinksFiles { get; }

    #endregion
}
