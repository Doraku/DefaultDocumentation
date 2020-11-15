@ECHO off

DEL /q package
dotnet clean source\DefaultDocumentation\DefaultDocumentation.csproj -c Release

dotnet build source\DefaultDocumentation\DefaultDocumentation.csproj -c Release /p:LOCAL_VERSION=true
dotnet pack source\DefaultDocumentation\DefaultDocumentation.csproj -c Release -o package --no-build /p:LOCAL_VERSION=true