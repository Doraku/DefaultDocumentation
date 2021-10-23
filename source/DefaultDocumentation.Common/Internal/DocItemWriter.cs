using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Internal
{
    internal sealed class DocItemWriter
    {
        private static readonly string[] _sections = new[]
        {
            "Header",
            "Title",
            "summary",
            "definition",
            "typeparameters",
            "parameters",
            "enumfields",
            "EventType",
            "FieldValue",
            "value",
            "returns",
            "exception",
            "Inheritance",
            "derived",
            "implement",
            "example",
            "remarks",
            "seealso",
            "constructors",
            "fields",
            "properties",
            "methods",
            "events",
            "operators",
            "explicitinterfaceimplementations",
            "classes",
            "structs",
            "interfaces",
            "enums",
            "delegates",
            "namespaces"
        };

        private readonly DocumentationContext _context;

        public DocItemWriter(Settings settings)
        {
            Dictionary<string, ISectionWriter> sectionWriters = Assembly
                .LoadFrom("DefaultDocumentation.Markdown.dll")
                .GetTypes()
                .Where(t => typeof(ISectionWriter).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (ISectionWriter)Activator.CreateInstance(t))
                .GroupBy(w => w.Name)
                .ToDictionary(w => w.Key, w => w.Last());

            _context = new DocumentationContext(
                settings,
                _sections.Select(s => sectionWriters.TryGetValue(s, out ISectionWriter writer) ? writer : null).Where(w => w != null).ToArray(),
                Assembly
                    .LoadFrom("DefaultDocumentation.Markdown.dll")
                    .GetTypes()
                    .Where(t => typeof(IElementWriter).IsAssignableFrom(t) && !t.IsAbstract)
                    .Select(t => (IElementWriter)Activator.CreateInstance(t))
                    .GroupBy(w => w.Name)
                    .ToDictionary(w => w.Key, w => w.Last()),
                DocItemReader.GetItems(settings));

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

        private void Clean()
        {
            _context.Settings.Logger.Debug($"Cleaning output folder \"{_context.Settings.OutputDirectory}\"");

            if (_context.Settings.OutputDirectory.Exists)
            {
                IEnumerable<FileInfo> files = _context.Settings.OutputDirectory.EnumerateFiles("*.md").Where(f => !string.Equals(f.Name, "readme.md", StringComparison.OrdinalIgnoreCase));

                int i;

                foreach (FileInfo file in files)
                {
                    i = 3;
                start:
                    try
                    {
                        file.Delete();
                    }
                    catch
                    {
                        if (--i > 0)
                        {
                            Thread.Sleep(100);
                            goto start;
                        }

                        throw;
                    }
                }

                i = 3;
                while (files.Any() && i-- > 0)
                {
                    Thread.Sleep(1000);
                }
            }
            else
            {
                _context.Settings.OutputDirectory.Create();
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

            File.WriteAllText(Path.Combine(_context.Settings.OutputDirectory.FullName, _context.GetFileName(item) + ".md"), builder.ToString());
        }

        private void WriteLinks()
        {
            if (_context.Settings.LinksOutputFile != null)
            {
                _context.Settings.Logger.Debug($"Writing links to file \"{_context.Settings.LinksOutputFile.FullName}\"");
                _context.Settings.LinksOutputFile.Directory.Create();

                using StreamWriter writer = _context.Settings.LinksOutputFile.CreateText();

                writer.WriteLine(_context.Settings.LinksBaseUrl);
                foreach (DocItem item in _context.Items.Where(i => i is not ExternDocItem && i is not AssemblyDocItem))
                {
                    writer.Write(item.Id);
                    writer.Write('|');
                    writer.Write(_context.GetUrl(item));
                    writer.Write('|');
                    writer.WriteLine(item.Name);
                }
            }
        }

        public void Execute()
        {
            Clean();

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
    }
}
