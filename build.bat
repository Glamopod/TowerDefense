@echo off
echo Cleaning previous build...
dotnet clean

echo.
echo Restoring packages...
dotnet restore

echo.
echo Building project...
dotnet build

IF %ERRORLEVEL% NEQ 0 (
    echo.
    echo Build failed! Press any key to exit...
    pause >nul
    exit /b %ERRORLEVEL%
)

echo.
echo Build successful! Running the application...
echo.
dotnet run --project TowerDefense/TowerDefense.csproj

pause 