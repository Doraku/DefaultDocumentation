using System;
using System.Linq;
using CommandLine;

namespace DefaultDocumentation;

internal static class Program
{
    private static int Main(string[] args)
    {
        using Parser parser = new(settings =>
        {
            settings.CaseSensitive = false;
            settings.CaseInsensitiveEnumValues = true;
            settings.HelpWriter = Console.Out;
        });

        return parser
            .ParseArguments<SettingsArgs>(args)
            .WithParsed(parsedArgs => Generator.Execute(logLevel => new ConsoleLogger(logLevel), parsedArgs))
            .Errors.Any() ? -1 : 0;
    }
}
