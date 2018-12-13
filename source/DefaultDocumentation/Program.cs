using System;
using System.IO;
using System.Xml.Linq;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("parameters:");
            Console.WriteLine("\t/xml:{xml documentation file path}");
            Console.WriteLine("\t/markdown:{markdown documentation output folder}");
        }

        private static void Main(string[] args)
        {
            FileInfo documentation = null;
            DirectoryInfo directory = null;

            foreach (string arg in args)
            {
                if (arg.StartsWith("/xml:"))
                {
                    documentation = new FileInfo(arg.Substring(5));
                }
                else if (arg.StartsWith("/markdown:") && !string.IsNullOrWhiteSpace(arg.Substring(10)))
                {
                    directory = new DirectoryInfo(arg.Substring(10));
                }
            }

            if (!(documentation?.Exists ?? false))
            {
                PrintHelp();
                return;
            }

            directory = directory ?? documentation.Directory;

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
