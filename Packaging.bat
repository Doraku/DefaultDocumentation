@ECHO off

DEL /q package
dotnet clean source\DefaultDocumentation.sln -c Release

dotnet pack source\DefaultDocumentation\DefaultDocumentation.csproj -c Release -o ..\..\package\