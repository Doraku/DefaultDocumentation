using System;
using System.Collections.Generic;
using System.Text;
using DefaultDocumentation.Model;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation.Internal
{
    internal sealed class PageWriter : IWriter
    {
        private class StringComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

            public int GetHashCode(string obj) => obj.ToUpperInvariant().GetHashCode();
        }

        private readonly StringBuilder _builder;
        private readonly Dictionary<string, object> _data;

        public PageWriter(StringBuilder builder, IGeneralContext context, DocItem item)
        {
            _builder = builder;
            _data = new Dictionary<string, object>(new StringComparer());

            Context = context;
            DocItem = item;
        }

        #region IWriter

        public IGeneralContext Context { get; }

        public DocItem DocItem { get; }

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
