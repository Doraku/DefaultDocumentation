using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace System.Text.Json.Nodes;

internal static class JsonObjectExtensions
{
    public static readonly JsonSerializerOptions JsonOptions;

    static JsonObjectExtensions()
    {
        JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };
        JsonOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public static bool TryGetPropertyIgnoringCase(this JsonObject element, string propertyName, [NotNullWhen(true)] out JsonNode? property)
    {
        property = element.FirstOrDefault(pair => string.Equals(pair.Key, propertyName, StringComparison.OrdinalIgnoreCase)).Value;

        return property is not null;
    }

    public static T? GetValue<T>(this JsonObject element, string propertyName)
        => element.TryGetPropertyIgnoringCase(propertyName, out JsonNode? property) ? property.Deserialize<T>(JsonOptions) : default;
}
