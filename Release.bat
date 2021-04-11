@ECHO off

DEL /q package
dotnet clean source\DefaultDocumentation.sln -c Release

dotnet pack source\DefaultDocumentation.sln -c Release -o build /p:LOCAL_VERSION=true