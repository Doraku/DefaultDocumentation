using System;
using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using Newtonsoft.Json.Linq;

namespace DefaultDocumentation.Internal;

internal class Context : IContext
{
    private readonly JObject _configuration;

    public Context(
        JObject configuration,
        Type[] availableTypes)
    {
        _configuration = configuration;

        string? fileNameFactory = GetSetting<string>(nameof(IRawSettings.FileNameFactory));
        FileNameFactory =
            string.IsNullOrEmpty(fileNameFactory)
            ? null
            : availableTypes
                .Where(type => typeof(IFileNameFactory).IsAssignableFrom(type) && !type.IsAbstract)
                .Select(type => (IFileNameFactory)Activator.CreateInstance(type))
                .LastOrDefault(fineNameFactory =>
                    fileNameFactory!.Equals(fineNameFactory.Name, StringComparison.OrdinalIgnoreCase)
                    || $"{fineNameFactory.GetType().FullName} {fineNameFactory.GetType().Assembly.GetName().Name}" == fileNameFactory)
                ?? throw new Exception($"FileNameFactory '{fileNameFactory}' not found");

        string[]? sections = GetSetting<string[]>(nameof(IRawSettings.Sections));

        if (sections != null)
        {
            Dictionary<string, ISection> availableSections = availableTypes
                .Where(type => typeof(ISection).IsAssignableFrom(type) && !type.IsAbstract)
                .Select(type => (ISection)Activator.CreateInstance(type))
                .GroupBy(section => section.Name, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(group => group.Key, group => group.Last(), StringComparer.OrdinalIgnoreCase);

            Sections = sections
                .Select(id =>
                    availableSections.TryGetValue(id, out ISection section)
                    ? section
                    : availableTypes
                        .Where(type => typeof(ISection).IsAssignableFrom(type) && !type.IsAbstract && $"{type.FullName} {type.Assembly.GetName().Name}" == id)
                        .Select(type => (ISection)Activator.CreateInstance(type))
                        .FirstOrDefault()
                    ?? throw new Exception($"Section '{id}' not found"))
                .ToArray();
        }
    }

    #region IContext

    public IFileNameFactory? FileNameFactory { get; }

    public IEnumerable<ISection>? Sections { get; }

    public T? GetSetting<T>(string name) => _configuration.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken? value) ? value.ToObject<T>() : default;

    #endregion
}
