@echo off
REM Build script for QuanLyBanHang project
REM This script compiles the project and checks for errors

echo.
echo ========================================
echo BUILD SCRIPT FOR QUANTLYBAN HANG
echo ========================================
echo.

REM Find MSBuild
set "VS_PATH=C:\Program Files\Microsoft Visual Studio\2022\Professional"
set "VS_PATH_ALT=C:\Program Files (x86)\Microsoft Visual Studio\2022\Professional"

if exist "%VS_PATH%\MSBuild\Current\Bin\MSBuild.exe" (
    set "MSBUILD=%VS_PATH%\MSBuild\Current\Bin\MSBuild.exe"
) else if exist "%VS_PATH_ALT%\MSBuild\Current\Bin\MSBuild.exe" (
    set "MSBUILD=%VS_PATH_ALT%\MSBuild\Current\Bin\MSBuild.exe"
) else (
    echo ERROR: MSBuild not found!
    echo Please install Visual Studio 2022 with C# development tools
    pause
    exit /b 1
)

echo Found MSBuild at: %MSBUILD%
echo.

REM Set project path
set "PROJECT_PATH=%~dp0QuanLyBanHang.csproj"
set "OUTPUT_DIR=%~dp0bin\Debug"

echo Project: %PROJECT_PATH%
echo Output:  %OUTPUT_DIR%
echo.

REM Clean previous build
echo Cleaning previous build...
if exist "%OUTPUT_DIR%" rmdir /s /q "%OUTPUT_DIR%"
echo.

REM Build Debug configuration
echo Building project (Debug)...
echo.

"%MSBUILD%" "%PROJECT_PATH%" /nologo /p:Configuration=Debug /p:Platform=AnyCPU /v:minimal

if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ========================================
    echo BUILD FAILED!
    echo ========================================
    echo.
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ========================================
echo BUILD SUCCESSFUL!
echo ========================================
echo.
echo Output: %OUTPUT_DIR%
echo.
echo The application is ready to run.
echo Executable: %OUTPUT_DIR%\QuanLyBanHang.exe
echo.

pause
