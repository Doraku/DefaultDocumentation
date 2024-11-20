@ECHO off

DEL /q package
dotnet clean source -c Release

dotnet test source -c Release

IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet pack source -c Release -o build /p:Version=0-local%Date:~6,4%%Date:~3,2%%Date:~0,2%%Time:~0,2%%Time:~3,2%%Time:~6,2% /p:SignAssembly=true

dotnet run --project source\DefaultDocumentation.Console\DefaultDocumentation.Console.csproj --framework net9.0 -c Release --ConfigurationFilePath source\DefaultDocumentation.Api\DefaultDocumentation.json
dotnet run --project source\DefaultDocumentation.Console\DefaultDocumentation.Console.csproj --framework net9.0 -c Release --ConfigurationFilePath source\DefaultDocumentation.Markdown\DefaultDocumentation.json

:end