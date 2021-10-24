using System;
using System.Collections.Generic;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class MarkdownWriter : IWriter
    {
        private readonly IWriter _writer;
        private readonly Dictionary<string, object> _data;

        public MarkdownWriter(IWriter writer)
        {
            _writer = writer;
            _data = new Dictionary<string, object>();
        }

        #region IWriter

        public DocumentationContext Context => _writer.Context;

        public DocItem DocItem => _writer.DocItem;

        public int Length
        {
            get => _writer.Length;
            set => _writer.Length = value;
        }

        public object this[string key]
        {
            get => (_data.TryGetValue(key, out object value) ? value : null) ?? _writer[key];
            set => _data[key] = value;
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
