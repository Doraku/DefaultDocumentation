using System;
using CommandLine;
using NLog.Targets;

namespace DefaultDocumentation;

internal static class Program
{
    private static void Main(string[] args)
    {
        using Parser parser = new(s =>
        {
            s.CaseSensitive = false;
            s.CaseInsensitiveEnumValues = true;
            s.HelpWriter = Console.Out;
        });

        parser
            .ParseArguments<SettingsArgs>(args)
            .WithParsed(a =>
            {
                using ConsoleTarget target = new("Console");

                Generator.Execute(target, a);
            });
    }
}
