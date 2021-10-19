param (
    [Parameter()]
    [string]$BasePath,

    [Parameter()]
    [string]$ApiName
)

$ErrorActionPreference = "Stop"

$Env:ASPNETCORE_URLS="http://0.0.0.0:5000/"
$api = Get-ChildItem $BasePath/app -Recurse | Where Name -match "$ApiName.dll"
dotnet $api.FullName