using System;
using CommandLine;

namespace DefaultDocumentation;

internal static class Program
{
    private static void Main(string[] args)
    {
        using Parser parser = new(settings =>
        {
            settings.CaseSensitive = false;
            settings.CaseInsensitiveEnumValues = true;
            settings.HelpWriter = Console.Out;
        });

        parser
            .ParseArguments<SettingsArgs>(args)
            .WithParsed(parsedArgs => Generator.Execute(logLevel => new ConsoleLogger(logLevel), parsedArgs));
    }
}
