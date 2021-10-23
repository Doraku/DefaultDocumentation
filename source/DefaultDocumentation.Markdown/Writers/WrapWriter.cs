using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class WrapWriter : IWriter
    {
        private readonly IWriter _writer;

        public WrapWriter(IWriter writer)
        {
            _writer = writer;
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
