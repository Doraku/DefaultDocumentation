using System;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class PrefixedWriter : IWriter
    {
        private readonly IWriter _writer;
        private readonly string _prefix;

        public PrefixedWriter(IWriter writer, string prefix)
        {
            _writer = writer;
            _prefix = prefix;
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
            get => _writer[key];
            set => _writer[key] = value;
        }

        public IWriter Append(string value)
        {
            if (!string.IsNullOrEmpty(value) && (Length is 0 || EndsWith(Environment.NewLine)))
            {
                _writer.Append(_prefix);
            }

            _writer.Append(value);

            return this;
        }

        public IWriter AppendLine()
        {
            _writer.AppendLine();

            return this;
        }

        public bool EndsWith(string value) => _writer.EndsWith(value);

        #endregion
    }
}
