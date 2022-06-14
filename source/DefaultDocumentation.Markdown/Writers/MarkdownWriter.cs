using System;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.Writers
{
    /// <summary>
    /// Decorator of the <see cref="IWriter"/> type to handle the <see href="https://github.com/Doraku/DefaultDocumentation#ignorelinebreak">Markdown.IgnoreLineBreak</see> setting.
    /// It also uses a <see cref="OverrideWriter"/> internally to further decorate the instance.
    /// </summary>
    public sealed class MarkdownWriter : IWriter
    {
        private readonly IWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownWriter"/> type.
        /// </summary>
        /// <param name="writer">The <see cref="IWriter"/> instance to decorate.</param>
        public MarkdownWriter(IWriter writer)
        {
            _writer = writer.ToOverrideWriter();
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
            get => _writer[key];
            set => _writer[key] = value;
        }

        /// <inheritdoc/>
        public IWriter Append(string value)
        {
            _writer.Append(value);

            return this;
        }

        /// <summary>
        /// Appends a <see cref="Environment.NewLine"/> or a <c><br/></c> at the end of the documentation text depending of the current setting.
        /// </summary>
        /// <returns>The current <see cref="IWriter"/>.</returns>
        public IWriter AppendLine()
        {
            if (Length > 0)
            {
                if (this.GetDisplayAsSingleLine())
                {
                    _writer.Append(this.GetIgnoreLineBreak() ? " " : "<br/>");
                }
                else
                {
                    _writer
                        .Append(this.GetIgnoreLineBreak() ? string.Empty : "  ")
                        .Append(Environment.NewLine);
                }
            }

            return this;
        }

        /// <inheritdoc/>
        public bool EndsWith(string value) => _writer.EndsWith(value);

        #endregion
    }
}
