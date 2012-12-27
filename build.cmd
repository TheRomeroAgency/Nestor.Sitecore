@echo off
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\build\psake.ps1' %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
pause
exit /b %ERRORLEVEL%
