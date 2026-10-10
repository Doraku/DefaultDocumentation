@ECHO off

ECHO *** Cleaning ***
DEL /q build
dotnet clean source -c Release

ECHO:
ECHO *** Testing ***
dotnet test source -c Release

IF %ERRORLEVEL% GTR 0 GOTO :end

ECHO:
ECHO *** Generating package(s) ***
dotnet pack source -c Release -o build /p:Version=0-local%Date:~6,4%%Date:~3,2%%Date:~0,2%%Time:~0,2%%Time:~3,2%%Time:~6,2% /p:SignAssembly=true

ECHO:
ECHO *** Generating default documentation ***
dotnet run --project source\DefaultDocumentation.Console\DefaultDocumentation.Console.csproj --framework net10.0 -c Release --ConfigurationFilePath source\DefaultDocumentation.Api\DefaultDocumentation.json
dotnet run --project source\DefaultDocumentation.Console\DefaultDocumentation.Console.csproj --framework net10.0 -c Release --ConfigurationFilePath source\DefaultDocumentation.Markdown\DefaultDocumentation.json

:end