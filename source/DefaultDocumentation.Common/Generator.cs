using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using DefaultDocumentation.Internal;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation
{
    public sealed class Generator
    {
        private static readonly string[] _plugins = new[]
        {
            "DefaultDocumentation.Markdown.dll"
        };

        private static readonly string[] _sections = new[]
        {
            "Header",
            "Default"
        };

        private readonly IFileNameFactory _fileNameFactory;
        private readonly DocumentationContext _context;

        private Generator(Settings settings)
        {
            Type[] availableTypes = _plugins
                .Select(Assembly.LoadFrom)
                .SelectMany(a => a.GetTypes())
                .ToArray();

            Dictionary<string, ISectionWriter> sectionWriters = availableTypes
                .Where(t => typeof(ISectionWriter).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (ISectionWriter)Activator.CreateInstance(t))
                .GroupBy(w => w.Name)
                .ToDictionary(w => w.Key, w => w.Last());

            _fileNameFactory = availableTypes
                .Where(t => typeof(IFileNameFactory).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (IFileNameFactory)Activator.CreateInstance(t))
                .LastOrDefault(f => f.Name == settings.FileNameFactory) ?? throw new Exception($"FileNameFactory {settings.FileNameFactory} not found");

            _context = new DocumentationContext(
                settings,
                _fileNameFactory,
                _sections.Select(s => sectionWriters.TryGetValue(s, out ISectionWriter writer) ? writer : null).Where(w => w != null).ToArray(),
                availableTypes
                    .Where(t => typeof(IElementWriter).IsAssignableFrom(t) && !t.IsAbstract)
                    .Select(t => (IElementWriter)Activator.CreateInstance(t))
                    .GroupBy(w => w.Name)
                    .ToDictionary(w => w.Key, w => w.Last()),
                DocItemReader.GetItems(settings));

            _context.Settings.Logger.Debug("FileNameFactory used:");
            _context.Settings.Logger.Debug($"\t{_fileNameFactory.Name}: {_fileNameFactory}");

            _context.Settings.Logger.Debug("SectionWriters used:");
            foreach (ISectionWriter section in _context.SectionWriters)
            {
                _context.Settings.Logger.Debug($"\t{section.Name}: {section}");
            }

            _context.Settings.Logger.Debug("ElementWriters used:");
            foreach (IElementWriter element in _context.ElementWriters.Values)
            {
                _context.Settings.Logger.Debug($"\t{element.Name}: {element}");
            }
        }

        private void WritePage(DocItem item, StringBuilder builder)
        {
            _context.Settings.Logger.Debug($"Writing DocItem \"{item}\" with id \"{item.Id}\"");
            builder.Clear();

            PageWriter writer = new(builder, _context, item);

            foreach (ISectionWriter sectionWriter in _context.SectionWriters)
            {
                sectionWriter.Write(writer);
            }

            builder.Replace(" />", "/>");

            File.WriteAllText(Path.Combine(_context.Settings.OutputDirectory.FullName, _context.GetFileName(item)), builder.ToString());
        }

        private void WriteLinks()
        {
            if (_context.Settings.LinksOutputFile != null)
            {
                _context.Settings.Logger.Debug($"Writing links to file \"{_context.Settings.LinksOutputFile.FullName}\"");
                _context.Settings.LinksOutputFile.Directory.Create();

                using StreamWriter writer = _context.Settings.LinksOutputFile.CreateText();

                writer.WriteLine(_context.Settings.LinksBaseUrl);
                foreach (DocItem item in _context.Items.Where(i => i is not ExternDocItem and not AssemblyDocItem))
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
            _fileNameFactory.Clean(_context);

            StringBuilder builder = new();

            foreach (DocItem item in _context.Items.Where(_context.HasOwnPage))
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

        public static void Execute(Settings settings)
        {
            using Mutex mutex = new(false, "DefaultDocumenation:" + settings.OutputDirectory.FullName.Replace('\\', '|').Replace('/', '|').TrimEnd('|'));
            if (!mutex.WaitOne(0))
            {
                settings.Logger.Warn($"An other instance of DefaultDocumentation is trying to generate a documentation to the same output directory \"{settings.OutputDirectory.FullName}\", the current one will stop");
                return;
            }

            try
            {
                new Generator(settings).Execute();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
