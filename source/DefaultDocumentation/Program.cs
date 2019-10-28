using System;
using System.IO;
using System.Xml.Linq;
using Mono.Cecil;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void PrintHelp()
        {
            Console.WriteLine("parameters:");
            Console.WriteLine("\t/assembly:{assembly file path}");
            Console.WriteLine("\t/xml:{xml documentation file path}");
            Console.WriteLine("\t/output:{DefaultDocumentation output folder}");
        }

        private static void Main(string[] args)
        {
            FileInfo assembly = null;
            FileInfo documentation = null;
            DirectoryInfo directory = null;

            foreach (string arg in args)
            {
                if (arg.StartsWith("/assembly:"))
                {
                    assembly = new FileInfo(arg.Substring(10));
                }
                else if (arg.StartsWith("/xml:"))
                {
                    documentation = new FileInfo(arg.Substring(5));
                }
                else if (arg.StartsWith("/output:") && !string.IsNullOrWhiteSpace(arg.Substring(10)))
                {
                    directory = new DirectoryInfo(arg.Substring(10));
                }
            }

            if (!(assembly?.Exists ?? false) || !(documentation?.Exists ?? false))
            {
                PrintHelp();
                return;
            }

            directory ??= documentation.Directory;

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
                AssemblyDefinition.ReadAssembly(assembly.FullName),
                XDocument.Parse(File.ReadAllText(documentation.FullName)),
                directory.FullName);
        }
    }
}
