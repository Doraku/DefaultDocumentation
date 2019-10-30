using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model;

namespace DefaultDocumentation
{
    internal sealed class DocumentationWriter : IDisposable
    {
        private static readonly ConcurrentQueue<StringBuilder> _builders = new ConcurrentQueue<StringBuilder>();

        private readonly StringBuilder _builder;
        private readonly DocItem _item;
        private readonly string _filePath;

        private DocumentationWriter(DocItem item, string filePath)
        {
            if (!_builders.TryDequeue(out _builder))
            {
                _builder = new StringBuilder(1024);
            }

            _item = item;
            _filePath = filePath;
        }

        public DocumentationWriter(string path, DocItem item)
            : this(item, Path.Combine(path, $"{item.Link}.md"))
        { }

        public DocumentationWriter(string path, string name)
            : this(default(DocItem), Path.Combine(path, $"{name.Clean()}.md"))
        { }

        public void WriteLine(string line) => _builder.AppendLine(line);

        public void Write(string line) => _builder.Append(line);

        public void Break() => _builder.AppendLine();

        public bool IsForThis(DocItem item) => _item == item;

        public void Dispose()
        {
            File.WriteAllText(_filePath, _builder.ToString());

            _builder.Clear();
            _builders.Enqueue(_builder);
        }
    }
}
