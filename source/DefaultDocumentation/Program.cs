using System;
using System.Collections.Generic;
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
            FileNameMode fileNameMode = FileNameMode.FullName;
            NestedTypeVisibility nestedTypeVisibility = NestedTypeVisibility.Namespace;
            string baselink = null;
            FileInfo linksfile = null;
            string externallinks = null;

            try
            {
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
                    else if (TryGetArgValue(arg, nameof(fileNameMode), out argValue))
                    {
                        fileNameMode = (FileNameMode)Enum.Parse(typeof(FileNameMode), argValue);
                    }
                    else if (TryGetArgValue(arg, nameof(nestedTypeVisibility), out argValue))
                    {
                        nestedTypeVisibility = (NestedTypeVisibility)Enum.Parse(typeof(NestedTypeVisibility), argValue);
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
            }
            catch
            {
                PrintHelp();
                throw;
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

            if (output.Exists)
            {
                foreach (FileInfo file in output.GetFiles("*.md"))
                {
                    int i = 3;
                start:
                    try
                    {
                        file.Delete();
                        continue;
                    }
                    catch
                    {
                        Console.WriteLine("welp");
                        if (--i > 0)
                        {
                            goto start;
                        }

                        throw;
                    }
                }
            }
            else
            {
                output.Create();
            }

            DocumentationGenerator generator = new DocumentationGenerator(assembly.FullName, xml.FullName, home, fileNameMode, nestedTypeVisibility, externallinks);

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
                Console.WriteLine($"\t/{nameof(fileNameMode)}:{{{string.Join(" | ", (IEnumerable<FileNameMode>)Enum.GetValues(typeof(FileNameMode)))}}}");
                Console.WriteLine($"\t/{nameof(nestedTypeVisibility)}:{{{string.Join(" | ", (IEnumerable<NestedTypeVisibility>)Enum.GetValues(typeof(NestedTypeVisibility)))}}}");
                Console.WriteLine($"\t/{nameof(baselink)}:{{base link path used if generating a links file}}");
                Console.WriteLine($"\t/{nameof(linksfile)}:{{links file path}}");
                Console.WriteLine($"\t/{nameof(externallinks)}:{{links files for element outside of this assembly, separated by '|'}}");
            }
        }
    }
}
