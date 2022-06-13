using System;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class MarkdownWriter : IWriter
    {
        private readonly IWriter _writer;

        public MarkdownWriter(IWriter writer)
        {
            _writer = new OverrideWriter(writer);
        }

        #region IWriter

        public IGeneralContext Context => _writer.Context;

        public DocItem DocItem => _writer.DocItem;

        public int Length
        {
            get => _writer.Length;
            set => _writer.Length = value;
        }

        public object? this[string key]
        {
            get => _writer[key];
            set => _writer[key] = value;
        }

        public IWriter Append(string value)
        {
            _writer.Append(value);

            return this;
        }

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

        public bool EndsWith(string value) => _writer.EndsWith(value);

        #endregion
    }
}
