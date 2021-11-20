using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal
{
    internal class Context : IContext
    {
        private readonly JObject _configuration;

        public Context(
            JObject configuration,
            Type[] availableTypes)
        {
            _configuration = configuration;

            string fileNameFactory = GetSetting<string>(nameof(FileNameFactory));
            FileNameFactory = string.IsNullOrEmpty(fileNameFactory) ? null : availableTypes
                .Where(t => typeof(IFileNameFactory).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => (IFileNameFactory)Activator.CreateInstance(t))
                .LastOrDefault(f => f.Name == fileNameFactory || $"{f.GetType().FullName} {f.GetType().Assembly.GetName().Name}" == fileNameFactory)
                ?? throw new Exception($"FileNameFactory '{fileNameFactory}' not found");

            string[] sections = GetSetting<string[]>(nameof(Sections));
            if (sections != null)
            {
                Dictionary<string, ISection> sectionWriters = availableTypes
                    .Where(t => typeof(ISection).IsAssignableFrom(t) && !t.IsAbstract)
                    .Select(t => (ISection)Activator.CreateInstance(t))
                    .GroupBy(w => w.Name)
                    .ToDictionary(w => w.Key, w => w.Last());

                Sections = sections
                    .Select(section =>
                        sectionWriters.TryGetValue(section, out ISection writer)
                        ? writer
                        : availableTypes
                            .Where(t => typeof(ISection).IsAssignableFrom(t) && !t.IsAbstract && $"{t.FullName} {t.Assembly.GetName().Name}" == section)
                            .Select(t => (ISection)Activator.CreateInstance(t))
                            .FirstOrDefault()
                        ?? throw new Exception($"SectionWriter '{section}' not found"))
                    .ToArray();
            }
        }

        #region IContext

        public IFileNameFactory FileNameFactory { get; }

        public IEnumerable<ISection> Sections { get; }

        public T GetSetting<T>(string name) => _configuration.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken value) ? value.ToObject<T>() : default;

        #endregion
    }
}
