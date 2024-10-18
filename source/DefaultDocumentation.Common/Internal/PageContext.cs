using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Internal;

internal sealed class PageContext : IPageContext
{
    private sealed class StringComparer : IEqualityComparer<string>
    {
        public bool Equals(string? x, string? y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

#if NET5_0_OR_GREATER
        public int GetHashCode(string obj) => obj.GetHashCode(StringComparison.OrdinalIgnoreCase);
#else
        public int GetHashCode(string obj) => obj.ToUpperInvariant().GetHashCode();
#endif
    }

    private readonly IGeneralContext _context;
    private readonly Dictionary<string, object?> _data;

    public PageContext(IGeneralContext context, DocItem item)
    {
        _data = new Dictionary<string, object?>(new StringComparer());

        _context = context;
        DocItem = item;
    }

    #region IPageContext

    public object? this[string key]
    {
        get => _data.TryGetValue(key, out object? value) ? value : null;
        set => _data[key] = value;
    }

    public DocItem DocItem { get; }

    public ISettings Settings => _context.Settings;

    public IReadOnlyDictionary<string, DocItem> Items => _context.Items;

    public IReadOnlyCollection<DocItem> ItemsWithOwnPage => _context.ItemsWithOwnPage;

    public IReadOnlyDictionary<string, IElement> Elements => _context.Elements;

    public IFileNameFactory? FileNameFactory => _context.FileNameFactory;

    public IEnumerable<ISection>? Sections => _context.Sections;

    public IEnumerable<IUrlFactory> UrlFactories => _context.UrlFactories;

    public IContext GetContext(Type? type) => _context.GetContext(type);

    public string GetFileName(DocItem item) => _context.GetFileName(item);

    public T? GetSetting<T>(string name) => _context.GetSetting<T>(name);

    #endregion
}
