@ECHO OFF

REM The following directory is for .NET 4.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

net stop ServiceTest.exe

echo UnInstalling Service from Windows Services...
echo ---------------------------------------------------------------
InstallUtil /i /u "%~dp0ServiceTest.exe"
echo ---------------------------------------------------------------
echo UnInstall Completed...
pause