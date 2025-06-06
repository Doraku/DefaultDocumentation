using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using DefaultDocumentation.Api;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Parameters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using static DefaultDocumentation.Internal.LoggerHelper;

namespace DefaultDocumentation;

public sealed class Generator
{
    private static readonly JsonSerializer _serializer;

    private readonly IRawSettings _settings;
    private readonly JObject _configuration;
    private readonly ILogger _logger;
    private readonly GeneralContext _context;

    static Generator()
    {
        _serializer = new JsonSerializer();
        _serializer.Converters.Add(new StringEnumConverter());
    }

    private Generator(Func<LogLevel, ILogger> loggerFactory, IRawSettings settings)
    {
        T? GetSetting<T>(string name) => _configuration.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken? value) ? value.ToObject<T>() : default;

        _settings = settings;
        _configuration = [];

        if (File.Exists(settings.ConfigurationFilePath))
        {
            _configuration = JObject.Parse(File.ReadAllText(settings.ConfigurationFilePath));
            Environment.CurrentDirectory = Path.GetDirectoryName(settings.ConfigurationFilePath);
        }

        AddSetting(settings => settings.LogLevel, value => !value.HasValue);
        AddSetting(settings => settings.AssemblyFilePath, string.IsNullOrEmpty);
        AddSetting(settings => settings.DocumentationFilePath, string.IsNullOrEmpty);
        AddSetting(settings => settings.ProjectDirectoryPath, string.IsNullOrEmpty);
        AddSetting(settings => settings.OutputDirectoryPath, string.IsNullOrEmpty);
        AddSetting(settings => settings.AssemblyPageName, string.IsNullOrEmpty);
        AddSetting(settings => settings.GeneratedAccessModifiers, value => value == GeneratedAccessModifiers.Default);
        AddSetting(settings => settings.IncludeUndocumentedItems, value => !value);
        AddSetting(settings => settings.GeneratedPages, value => value == GeneratedPages.Default);
        AddSetting(settings => settings.LinksOutputFilePath, string.IsNullOrEmpty);
        AddSetting(settings => settings.LinksBaseUrl, string.IsNullOrEmpty);
        AddSetting(settings => settings.ExternLinksFilePaths, value => !(value ?? []).Any(), value => value.ToArray());
        // context settings
        AddSetting(settings => settings.Plugins, value => !(value ?? []).Any(), value => value.ToArray());
        AddSetting(settings => settings.DocItemGenerators, value => !(value ?? []).Any(), ["Exclude", "Overloads"]);
        AddSetting(settings => settings.FileNameFactory, string.IsNullOrEmpty, "FullName");
        AddSetting(settings => settings.UrlFactories, value => !(value ?? []).Any(), value => value.ToArray(), ["DocItem", "DotnetApi"]);
        AddSetting(settings => settings.Sections, value => !(value ?? []).Any(), value => value.ToArray(), ["Header", "Default"]);
        AddSetting(settings => settings.Elements, value => !(value ?? []).Any(), value => value.ToArray());

        _logger = loggerFactory(GetSetting<LogLevel?>(nameof(LogLevel)) ?? LogLevel.Information);
        LogStarting(_logger, _configuration);

        Settings resolvedSettings = new(
            _logger,
            GetSetting<string>(nameof(settings.AssemblyFilePath)),
            GetSetting<string>(nameof(settings.DocumentationFilePath)),
            GetSetting<string>(nameof(settings.ProjectDirectoryPath)),
            GetSetting<string>(nameof(settings.OutputDirectoryPath)),
            GetSetting<string>(nameof(settings.AssemblyPageName)),
            GetSetting<GeneratedAccessModifiers>(nameof(settings.GeneratedAccessModifiers)),
            GetSetting<GeneratedPages>(nameof(settings.GeneratedPages)),
            GetSetting<bool>(nameof(settings.IncludeUndocumentedItems)),
            GetSetting<string>(nameof(settings.LinksOutputFilePath)),
            GetSetting<string>(nameof(settings.LinksBaseUrl)),
            GetSetting<string[]>(nameof(settings.ExternLinksFilePaths)));

        LogStarting(_logger, resolvedSettings);

        resolvedSettings.Validate();

        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            AssemblyName assemblyName = new(args.Name);

            Assembly? loadedAssembly = Array.Find(((AppDomain)sender).GetAssemblies(), assemby => assemby.GetName().Name.Equals(assemblyName.Name, StringComparison.OrdinalIgnoreCase));

            if (loadedAssembly?.GetName() is AssemblyName loadedAssemblyName
                && loadedAssemblyName.Version != assemblyName.Version)
            {
                if (loadedAssemblyName.Version.Major == assemblyName.Version.Major)
                {
                    // there shouldn't be any breaking changes
                    LogAssemblyDifferentVersionAsInformation(_logger, loadedAssemblyName, assemblyName);
                }
                else
                {
                    LogAssemblyDifferentVersionAsWarning(_logger, loadedAssemblyName, assemblyName);
                }
            }

            return loadedAssembly;
        };

        _context = new GeneralContext(
            _configuration,
                [.. ((Assembly[])[
                    typeof(DocItem).Assembly,
                    typeof(Markdown.Writers.MarkdownWriter).Assembly
                ])
                .Concat((GetSetting<string[]>(nameof(settings.Plugins)) ?? Enumerable.Empty<string>()).Select(Assembly.LoadFrom))
                .SelectMany(assembly => assembly.GetTypes())],
            resolvedSettings);
    }

    private void AddSetting<TSetting, TConfig>(
        Expression<Func<IRawSettings, TSetting>> property,
        Predicate<TSetting> noValuePredicate,
        Func<TSetting, TConfig> convert,
        TConfig? defaultValue = default)
    {
        string name = ((MemberExpression)property.Body).Member.Name;
        TSetting value = property.Compile().Invoke(_settings);

        if (!noValuePredicate(value))
        {
            _configuration.Property(name, StringComparison.OrdinalIgnoreCase)?.Remove();
            _configuration.Add(name, JToken.FromObject(convert(value)!, _serializer));
        }
        else if (!Equals(defaultValue, default(TConfig))
            && (!(_configuration.Property(name, StringComparison.OrdinalIgnoreCase) is { } configurationProperty)
                || configurationProperty.Value?.Type is null or JTokenType.Null))
        {
            _configuration.Property(name, StringComparison.OrdinalIgnoreCase)?.Remove();
            _configuration.Add(name, JToken.FromObject(defaultValue!, _serializer));
        }
    }

    private void AddSetting<TSetting>(
        Expression<Func<IRawSettings, TSetting>> property,
        Predicate<TSetting> noValuePredicate,
        TSetting? defaultValue = default)
        => AddSetting(property, noValuePredicate, value => value, defaultValue);

    private void WritePage(DocItem item, StringBuilder builder)
    {
        LogWritingDocItem(_logger, item);
        builder.Clear();

        PageWriter writer = new(builder, new PageContext(_context, item));

        foreach (ISection sectionWriter in writer.Context.GetSetting(item, context => context.Sections) ?? [])
        {
            sectionWriter.Write(writer);
        }

        builder.Replace(" />", "/>");

        string fileName = Path.Combine(_context.Settings.OutputDirectory.FullName, _context.GetFileName(item));

        Directory.CreateDirectory(Path.GetDirectoryName(fileName));
        File.WriteAllText(fileName, builder.ToString());
    }

    private void WriteLinks()
    {
        if (_context.Settings.LinksOutputFile != null)
        {
            LogWritingLinksFile(_logger, _context.Settings.LinksOutputFile);
            _context.Settings.LinksOutputFile.Directory.Create();

            using StreamWriter writer = _context.Settings.LinksOutputFile.CreateText();

            PageContext context = new(_context, new ExternDocItem("T:", "", ""));

            writer.WriteLine(_context.Settings.LinksBaseUrl);
            foreach (DocItem item in _context.Items.Values.Where(item => item is not ExternDocItem and not AssemblyDocItem and not TypeParameterDocItem and not ParameterDocItem))
            {
                writer.Write(item.Id);
                writer.Write('|');
                writer.Write(context.GetUrl(item));
                writer.Write('|');
                writer.WriteLine(item.Name);
            }
        }
    }

    private void Execute()
    {
        foreach (IFileNameFactory fileNameFactory in _context.AllFileNameFactory)
        {
            fileNameFactory.Clean(_context);
        }

        StringBuilder builder = new();

        foreach (DocItem item in _context.ItemsWithOwnPage)
        {
            try
            {
                WritePage(item, builder);
            }
            catch (Exception exception)
            {
                throw new Exception($"Error while writing documentation for {item.FullName}", exception);
            }
        }

        WriteLinks();

        LogDocumentationGenerated(_logger, _context.Settings.OutputDirectory);
    }

    public static void Execute(Func<LogLevel, ILogger> loggerFactory, IRawSettings settings)
    {
        loggerFactory.ThrowIfNull();
        settings.ThrowIfNull();

        Generator generator = new(loggerFactory, settings);

        using Mutex mutex = new(false, "DefaultDocumenation:" + generator._context.Settings.OutputDirectory.FullName.Replace('\\', '|').Replace('/', '|').TrimEnd('|'));
        if (!mutex.WaitOne(0))
        {
            LogDocumentationAlreadyGenerating(generator._logger, generator._context.Settings.OutputDirectory);
            return;
        }

        try
        {
            generator.Execute();
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}
