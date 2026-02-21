using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.Writers;

/// <summary>
/// Decorator of the <see cref="IWriter"/> type to override its data without changing its actual values.
/// </summary>
public sealed class OverrideWriter : IWriter
{
    private sealed class StringComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

        public int GetHashCode(string obj) => obj.ToUpperInvariant().GetHashCode();
    }

    private sealed class OverrideContext : IPageContext
    {
        private readonly IPageContext _context;
        private readonly Dictionary<string, object?> _data;

        public OverrideContext(IPageContext context)
        {
            _context = context;
            _data = new Dictionary<string, object?>(new StringComparer());
        }

        #region IPageContext

        public object? this[string key]
        {
            get => (_data.TryGetValue(key, out object? value) ? value : null) ?? _context[key];
            set => _data[key] = value;
        }

        public DocItem DocItem => _context.DocItem;

        public ISettings Settings => _context.Settings;

        public IReadOnlyDictionary<string, DocItem> Items => _context.Items;

        public IReadOnlyCollection<DocItem> ItemsWithOwnPage => _context.ItemsWithOwnPage;

        public IReadOnlyDictionary<string, IElement> Elements => _context.Elements;

        public IEnumerable<IUrlFactory> UrlFactories => _context.UrlFactories;

        public IFileNameFactory? FileNameFactory => _context.FileNameFactory;

        public IEnumerable<ISection>? Sections => _context.Sections;

        public IContext GetContext(Type? type) => _context.GetContext(type);

        public string GetFileName(DocItem item) => _context.GetFileName(item);

        public T? GetSetting<T>(string name) => _context.GetSetting<T>(name);

        #endregion
    }

    private readonly IWriter _writer;

    /// <summary>
    /// Initializes a new instance of the <see cref="OverrideWriter"/> type.
    /// </summary>
    /// <param name="writer">The <see cref="IWriter"/> instance to decorate.</param>
    public OverrideWriter(IWriter writer)
    {
        ArgumentNullException.ThrowIfNull(writer);

        _writer = writer;
        Context = new OverrideContext(writer.Context);
    }

    #region IWriter

    /// <inheritdoc/>
    public IPageContext Context { get; }

    /// <inheritdoc/>
    public int Length
    {
        get => _writer.Length;
        set => _writer.Length = value;
    }

    /// <inheritdoc/>
    public IWriter Append(string value)
    {
        _writer.Append(value);

        return this;
    }

    /// <inheritdoc/>
    public IWriter AppendLine()
    {
        _writer.AppendLine();

        return this;
    }

    /// <inheritdoc/>
    public bool EndsWith(string value) => _writer.EndsWith(value);

    #endregion
}
