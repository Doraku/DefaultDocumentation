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

        FileNameFactory = GetImplementations<IFileNameFactory>(availableTypes, fileNameFactory => fileNameFactory.Name, [GetSetting<string>(nameof(IRawSettings.FileNameFactory))])?.FirstOrDefault();
        Sections = GetImplementations<ISection>(availableTypes, section => section.Name, GetSetting<string[]>(nameof(IRawSettings.Sections)));
    }

    protected static IReadOnlyDictionary<string, T> GetAllAvailableImplementations<T>(IEnumerable<Type> availableTypes, Func<T, string> keySelector)
        => availableTypes
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (T)Activator.CreateInstance(type))
            .GroupBy(section => keySelector(section), StringComparer.OrdinalIgnoreCase)
            .ToDictionary(group => group.Key, group => group.Last(), StringComparer.OrdinalIgnoreCase);

    protected static T GetImplementation<T>(IEnumerable<Type> availableTypes, string typeName)
        => availableTypes
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsAbstract && $"{type.FullName} {type.Assembly.GetName().Name}" == typeName)
            .Select(type => (T)Activator.CreateInstance(type))
            .FirstOrDefault()
            ?? throw new Exception($"{typeof(T).Name} '{typeName}' not found");

    protected static T[]? GetImplementations<T>(
        IEnumerable<Type> availableTypes,
        Func<T, string> keySelector,
        string?[]? values)
    {
        if (values?.All(string.IsNullOrEmpty) != false)
        {
            return null;
        }

        IReadOnlyDictionary<string, T> availableImplementations = GetAllAvailableImplementations(availableTypes, keySelector);

        return values
            .Where(value => !string.IsNullOrEmpty(value))
            .Select(value =>
                availableImplementations.TryGetValue(value!, out T implementation)
                ? implementation
                : GetImplementation<T>(availableTypes, value!))
            .ToArray();
    }

    #region IContext

    public IFileNameFactory? FileNameFactory { get; }

    public IEnumerable<ISection>? Sections { get; }

    public T? GetSetting<T>(string name) => _configuration.TryGetValue(name, StringComparison.OrdinalIgnoreCase, out JToken? value) ? value.ToObject<T>() : default;

    #endregion
}
