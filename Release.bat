@ECHO off

DEL /q package
dotnet clean source\DefaultDocumentation.sln -c Release

dotnet pack source\DefaultDocumentation.sln -c Release -o build /p:LOCAL_VERSION=true

dotnet run --project source\DefaultDocumentation.Console\DefaultDocumentation.Console.csproj --framework net6.0 -c Release --ConfigurationFilePath source\DefaultDocumentation.Api\DefaultDocumentation.json