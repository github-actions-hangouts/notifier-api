param (
    [Parameter()]
    [string]$BasePath,

    [Parameter()]
    [string]$ApiName
)

$ErrorActionPreference = "Stop"

$api = Get-ChildItem $BasePath\app | Where Name -match "$ApiName.dll"
dotnet $api.FullName --urls=http://0.0.0.0:5000/