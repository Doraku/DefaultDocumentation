using System;
using System.IO;
using System.Text;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation
{
    internal sealed class DocWriter : IDisposable
    {
        private readonly StringBuilder _builder;
        private readonly ADocItem _item;
        private readonly string _filePath;

        private DocWriter(ADocItem item, string filePath)
        {
            _builder = new StringBuilder();
            _item = item;
            _filePath = filePath;
        }

        public DocWriter(string path, ADocItem item)
            : this(item, Path.Combine(path, $"{item.FullName.CleanForLink()}.md"))
        { }

        public DocWriter(string path, string name)
            : this(default(ADocItem), Path.Combine(path, $"{name.CleanForLink()}.md"))
        { }

        public void Write(string line) => _builder.AppendLine(line);

        public void Break() => _builder.AppendLine();

        public bool IsForThis(ADocItem item) => _item == item;

        public void Dispose()
        {
            File.WriteAllText(_filePath, _builder.ToString());
        }
    }
}
