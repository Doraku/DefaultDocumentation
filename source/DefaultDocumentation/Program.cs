using System;
using System.IO;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            FileInfo assembly = null;
            FileInfo xml = null;
            DirectoryInfo output = null;
            string home = null;
            string baselink = null;
            FileInfo linksfile = null;
            string externallinks = null;

            foreach (string arg in args)
            {
                if (TryGetArgValue(arg, nameof(assembly), out string argValue))
                {
                    assembly = new FileInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(xml), out argValue))
                {
                    xml = new FileInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(output), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    output = new DirectoryInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(home), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    home = argValue;
                }
                else if (TryGetArgValue(arg, nameof(baselink), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    baselink = argValue;
                }
                else if (TryGetArgValue(arg, nameof(linksfile), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    linksfile = new FileInfo(argValue);
                }
                else if (TryGetArgValue(arg, nameof(externallinks), out argValue) && !string.IsNullOrWhiteSpace(argValue))
                {
                    externallinks = argValue;
                }
            }

            if (assembly is null || xml is null)
            {
                PrintHelp();
                return;
            }
            else if (!assembly.Exists)
            {
                Console.WriteLine($"assembly file \"{assembly.FullName}\" not found");
                return;
            }
            else if (!xml.Exists)
            {
                Console.WriteLine($"documentation file \"{xml.FullName}\" not found");
                return;
            }

            output ??= xml.Directory;
            home ??= "index";

            if (output.Exists)
            {
                foreach (FileInfo file in output.GetFiles("*.md"))
                {
                    file.Delete();
                }
            }
            else
            {
                output.Create();
            }

            DocumentationGenerator generator = new DocumentationGenerator(assembly.FullName, xml.FullName, home, externallinks);

            generator.WriteDocumentation(output.FullName);

            if (linksfile != null)
            {
                if (linksfile.Exists)
                {
                    linksfile.Delete();
                }

                generator.WriteLinks(baselink, linksfile.FullName);
            }

            static bool TryGetArgValue(string arg, string argName, out string value)
            {
                value = null;
                if (arg.StartsWith($"/{argName}:"))
                {
                    value = arg.Substring(argName.Length + 2);
                }

                return value != null;
            }

            void PrintHelp()
            {
                Console.WriteLine("parameters:");
                Console.WriteLine($"\t/{nameof(assembly)}:{{assembly file path}}");
                Console.WriteLine($"\t/{nameof(xml)}:{{xml documentation file path}}");
                Console.WriteLine("optional parameters:");
                Console.WriteLine($"\t/{nameof(output)}:{{DefaultDocumentation output folder}}");
                Console.WriteLine($"\t/{nameof(home)}:{{DefaultDocumentation home page name}}");
                Console.WriteLine($"\t/{nameof(baselink)}:{{base link path used if generating a links file}}");
                Console.WriteLine($"\t/{nameof(linksfile)}:{{links file path}}");
                Console.WriteLine($"\t/{nameof(externallinks)}:{{links files for element outside of this assembly, separated by '|'}}");
            }
        }
    }
}
