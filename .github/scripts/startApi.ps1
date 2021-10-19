param (
    [Parameter()]
    [string]$ApiName
)

$ErrorActionPreference = "Stop"

$Env:ASPNETCORE_URLS="http://0.0.0.0:5000/"
dotnet "./app/$ApiName.dll"