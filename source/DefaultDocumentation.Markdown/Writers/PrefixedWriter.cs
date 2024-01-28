using System;
using DefaultDocumentation.Api;

namespace DefaultDocumentation.Markdown.Writers
{
    /// <summary>
    /// Decorator of the <see cref="IWriter"/> type to prefix every new line with a specific <see cref="string"/>.
    /// </summary>
    public sealed class PrefixedWriter : IWriter
    {
        private readonly IWriter _writer;
        private readonly string _prefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixedWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> instance to decorate.</param>
        /// <param name="prefix">The prefix to use at every new line start.</param>
        public PrefixedWriter(IWriter writer, string prefix)
        {
            ArgumentNullException.ThrowIfNull(writer);
            ArgumentNullException.ThrowIfNull(prefix);

            _writer = writer;
            _prefix = prefix;
        }

        #region IWriter

        /// <inheritdoc/>
        public IPageContext Context => _writer.Context;

        /// <inheritdoc/>
        public int Length
        {
            get => _writer.Length;
            set => _writer.Length = value;
        }

        /// <inheritdoc/>
        public IWriter Append(string value)
        {
            if (!string.IsNullOrEmpty(value) && (Length is 0 || EndsWith(Environment.NewLine)))
            {
                _writer.Append(_prefix);
            }

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
