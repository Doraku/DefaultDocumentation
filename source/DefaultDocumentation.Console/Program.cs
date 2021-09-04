using System;
using System.Collections.Generic;
using CommandLine;
using NLog.Targets;

namespace DefaultDocumentation
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            static T GetEnum<T>(IEnumerable<T> values)
                where T : Enum, IConvertible
            {
                int value = 0;
                foreach (T flag in values)
                {
                    value |= flag.ToInt32(null);
                }

                return (T)(object)value;
            }

            new Parser(s =>
            {
                s.CaseSensitive = false;
                s.CaseInsensitiveEnumValues = true;
                s.HelpWriter = Console.Out;
            })
                .ParseArguments<SettingsArgs>(args)
                .WithParsed(a =>
                {
                    Generator.Execute(new Settings(
                        new ConsoleTarget("Console"),
                        a.LogLevel,
                        a.AssemblyFilePath,
                        a.DocumentationFilePath,
                        a.ProjectDirectoryPath,
                        a.OutputDirectoryPath,
                        a.AssemblyPageName,
                        a.InvalidCharReplacement,
                        a.FileNameMode,
                        a.RemoveFileExtensionFromLinks,
                        GetEnum(a.NestedTypeVisibilities),
                        GetEnum(a.GeneratedPages),
                        GetEnum(a.GeneratedAccessModifiers),
                        a.IgnoreLineBreak,
                        a.LinksOutputFilePath,
                        a.LinksBaseUrl,
                        a.ExternLinksFilePaths));
                });
        }
    }
}
