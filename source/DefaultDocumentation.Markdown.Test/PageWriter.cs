using System.Collections.Generic;
using System.Text;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Markdown
{
    internal sealed class PageWriter : IWriter
    {
        private readonly StringBuilder _builder;
        private readonly Dictionary<string, object> _data;

        public PageWriter(StringBuilder builder, DocumentationContext context, DocItem item)
        {
            _builder = builder;
            _data = new Dictionary<string, object>();

            Context = context;
            PageItem = item;
            CurrentItem = item;
        }

        #region IWriter

        public DocumentationContext Context { get; }

        public DocItem PageItem { get; }

        public DocItem CurrentItem { get; }

        public int Length
        {
            get => _builder.Length;
            set => _builder.Length = value;
        }

        public object this[string key]
        {
            get => _data.TryGetValue(key, out object value) ? value : null;
            set => _data[key] = value;
        }

        public IWriter Append(string value)
        {
            _builder.Append(value);

            return this;
        }

        public IWriter AppendLine()
        {
            if (Length > 0)
            {
                _builder.AppendLine();
            }

            return this;
        }

        public bool EndsWith(string value)
        {
            if (_builder.Length < value.Length)
            {
                return false;
            }

            for (int i = 0; i < value.Length; ++i)
            {
                if (value[i] != _builder[_builder.Length - value.Length + i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
