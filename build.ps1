Write-Host "Cleaning previous build..."
dotnet clean

Write-Host "`nRestoring packages..."
dotnet restore

Write-Host "`nBuilding project..."
dotnet build

if ($LASTEXITCODE -ne 0) {
    Write-Host "`nBuild failed! Press any key to exit..."
    $null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown')
    exit $LASTEXITCODE
}

Write-Host "`nBuild successful! Running the application..."
dotnet run --project TowerDefense/TowerDefense.csproj

pause 