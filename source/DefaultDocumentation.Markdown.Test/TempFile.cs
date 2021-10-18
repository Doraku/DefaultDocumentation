using System;
using System.IO;

namespace DefaultDocumentation.Markdown
{
    public sealed class TempFile : IDisposable
    {
        public FileInfo Info { get; }

        public TempFile(string filePath, string content)
        {
            Info = new FileInfo(filePath);
            File.WriteAllText(Info.FullName, content);
        }

        public void Dispose() => Info.Delete();
    }
}
