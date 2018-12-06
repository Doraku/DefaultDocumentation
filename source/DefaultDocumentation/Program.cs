using System.IO;
using System.Xml.Linq;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }

            FileInfo documentation = new FileInfo(args[0]);
            if (!documentation.Exists)
            {
                return;
            }

            DirectoryInfo directory =
                args.Length > 1 && !string.IsNullOrWhiteSpace(args[1])
                ? new DirectoryInfo(args[1])
                : documentation.Directory;

            if (directory.Exists)
            {
                foreach (FileInfo file in directory.GetFiles("*.md"))
                {
                    file.Delete();
                }
            }
            else
            {
                directory.Create();
            }

            Converter.Convert(
                XDocument.Parse(File.ReadAllText(documentation.FullName)),
                directory.FullName);
        }
    }
}
