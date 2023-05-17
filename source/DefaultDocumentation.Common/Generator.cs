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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace DefaultDocumentation
{
    public sealed class Generator
    {
        private static readonly JsonSerializer _serializer;

        private readonly JObject _configuration;
        private readonly ILogger _logger;
        private readonly GeneralContext _context;

        static Generator()
        {
            _serializer = new JsonSerializer();
            _serializer.Converters.Add(new StringEnumConverter());
        }

        private Generator(Target loggerTarget, IRawSettings settings)
        {
            T GetSetting<T>(string name) => _configuration.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken value) ? value.ToObject<T>() : default;

            void AddSetting<TSetting, TConfig>(Expression<Func<IRawSettings, TSetting>> property, Predicate<TSetting> noValue, Func<TSetting, TConfig> convert)
            {
                string name = ((MemberExpression)property.Body).Member.Name;
                TSetting value = property.Compile().Invoke(settings);

                if (!noValue(value))
                {
                    _configuration.Property(name, StringComparison.OrdinalIgnoreCase)?.Remove();
                    _configuration.Add(name, JToken.FromObject(convert(value), _serializer));
                }
            }

            _configuration = new JObject();

            if (File.Exists(settings.ConfigurationFilePath))
            {
                _configuration = JObject.Parse(File.ReadAllText(settings.ConfigurationFilePath));
                Environment.CurrentDirectory = Path.GetDirectoryName(settings.ConfigurationFilePath);
            }

            AddSetting(s => s.LogLevel, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.AssemblyFilePath, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.DocumentationFilePath, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.ProjectDirectoryPath, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.OutputDirectoryPath, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.AssemblyPageName, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.GeneratedAccessModifiers, v => v == GeneratedAccessModifiers.Default, v => v);
            AddSetting(s => s.IncludeUndocumentedItems, v => !v, v => v);
            AddSetting(s => s.GeneratedPages, v => v == GeneratedPages.Default, v => v);
            AddSetting(s => s.LinksOutputFilePath, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.LinksBaseUrl, string.IsNullOrEmpty, v => v);
            AddSetting(s => s.ExternLinksFilePaths, v => !(v ?? Enumerable.Empty<string>()).Any(), v => v.ToArray());
            // context settings
            AddSetting(s => s.Plugins, v => !(v ?? Enumerable.Empty<string>()).Any(), v => v.ToArray());
            AddSetting(s => s.FileNameFactory, string.IsNullOrEmpty, v => v);
            if (string.IsNullOrEmpty(GetSetting<string>(nameof(settings.FileNameFactory))))
            {
                AddSetting(s => s.FileNameFactory, _ => false, _ => "FullName");
            }
            AddSetting(s => s.UrlFactories, v => !(v ?? Enumerable.Empty<string>()).Any(), v => v.ToArray());
            if (GetSetting<string[]>(nameof(settings.UrlFactories)) is null)
            {
                AddSetting(s => s.UrlFactories, _ => false, _ => new[] { "DocItem", "DotnetApi" });
            }
            AddSetting(s => s.Sections, v => !(v ?? Enumerable.Empty<string>()).Any(), v => v.ToArray());
            if (GetSetting<string[]>(nameof(settings.Sections)) is null)
            {
                AddSetting(s => s.Sections, _ => false, _ => new[] { "Header", "Default" });
            }
            AddSetting(s => s.Elements, v => !(v ?? Enumerable.Empty<string>()).Any(), v => v.ToArray());

            string logLevel = GetSetting<string>(nameof(logLevel));
            if (loggerTarget != null)
            {
                LoggingConfiguration logConfiguration = new();
                logConfiguration.AddTarget(loggerTarget);
                logConfiguration.AddRule(LogLevel.FromString(string.IsNullOrEmpty(logLevel) ? nameof(LogLevel.Info) : logLevel), LogLevel.Fatal, loggerTarget);
                LogManager.Configuration = logConfiguration;
            }

            _logger = LogManager.GetLogger("DefaultDocumentation");
            _logger.Info($"Starting DefaultDocumentation with this configuration:{Environment.NewLine}{_configuration.ToString(Formatting.Indented)}");

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

            AppDomain.CurrentDomain.AssemblyResolve += OnResolve;
            _context = new GeneralContext(
                _configuration,
                new[] { typeof(Markdown.Writers.MarkdownWriter).Assembly }
                    .Concat((GetSetting<string[]>(nameof(settings.Plugins)) ?? Enumerable.Empty<string>()).Select(Assembly.LoadFrom))
                    .SelectMany(a => a.GetTypes())
                    .ToArray(),
                resolvedSettings,
                DocItemReader.GetItems(resolvedSettings));
        }

        private Assembly OnResolve(Object sender, ResolveEventArgs e)
        {
            return Array.Find(AppDomain.CurrentDomain.GetAssemblies(), asm => asm.FullName == e.Name);
        }

        private void WritePage(DocItem item, StringBuilder builder)
        {
            _context.Settings.Logger.Debug($"Writing DocItem \"{item}\" with id \"{item.Id}\"");
            builder.Clear();

            PageWriter writer = new(builder, _context, item);

            foreach (ISection sectionWriter in writer.Context.GetSetting(item, c => c.Sections))
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
                _context.Settings.Logger.Debug($"Writing links to file \"{_context.Settings.LinksOutputFile.FullName}\"");
                _context.Settings.LinksOutputFile.Directory.Create();

                using StreamWriter writer = _context.Settings.LinksOutputFile.CreateText();

                writer.WriteLine(_context.Settings.LinksBaseUrl);
                foreach (DocItem item in _context.Items.Values.Where(i => i is not ExternDocItem and not AssemblyDocItem and not TypeParameterDocItem and not ParameterDocItem))
                {
                    writer.Write(item.Id);
                    writer.Write('|');
                    writer.Write(_context.GetUrl(item));
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

            foreach (DocItem item in _context.Items.Values.Where(i => i.HasOwnPage(_context)))
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

            _context.Settings.Logger.Info($"Documentation generated to output folder \"{_context.Settings.OutputDirectory}\"");
        }

        public static void Execute(Target loggerTarget, IRawSettings settings)
        {
            Generator generator = new(loggerTarget, settings);

            using Mutex mutex = new(false, "DefaultDocumenation:" + generator._context.Settings.OutputDirectory.FullName.Replace('\\', '|').Replace('/', '|').TrimEnd('|'));
            if (!mutex.WaitOne(0))
            {
                generator._context.Settings.Logger.Warn($"An other instance of DefaultDocumentation is trying to generate a documentation to the same output directory \"{generator._context.Settings.OutputDirectory.FullName}\", the current one will stop");
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
}
