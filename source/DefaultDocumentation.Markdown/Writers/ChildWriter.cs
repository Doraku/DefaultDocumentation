using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown.Writers
{
    public sealed class ChildWriter : IWriter
    {
        private readonly IWriter _writer;

        public ChildWriter(IWriter writer, DocItem currentItem)
        {
            _writer = writer;
            CurrentItem = currentItem;
        }

        #region IWriter

        public DocumentationContext Context => _writer.Context;

        public DocItem PageItem => _writer.PageItem;

        public DocItem CurrentItem { get; }

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
