using System;
using System.Collections.Generic;
using DefaultDocumentation.Api;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.Writers
{
    /// <summary>
    /// Decorator of the <see cref="IWriter"/> type to override its data without changing its actual values.
    /// </summary>
    public sealed class OverrideWriter : IWriter
    {
        private class StringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

            public int GetHashCode(string obj) => obj.ToUpperInvariant().GetHashCode();
        }

        private readonly IWriter _writer;
        private readonly Dictionary<string, object?> _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverrideWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> instance to decorate.</param>
        public OverrideWriter(IWriter writer)
        {
            _writer = writer;
            _data = new Dictionary<string, object?>(new StringComparer());
        }

        #region IWriter

        /// <inheritdoc/>
        public IGeneralContext Context => _writer.Context;

        /// <inheritdoc/>
        public DocItem DocItem => _writer.DocItem;

        /// <inheritdoc/>
        public int Length
        {
            get => _writer.Length;
            set => _writer.Length = value;
        }

        /// <inheritdoc/>
        public object? this[string key]
        {
            get => (_data.TryGetValue(key, out object? value) ? value : null) ?? _writer[key];
            set => _data[key] = value;
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
}
