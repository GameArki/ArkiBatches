@REM Usage: compile.cmd [dstExe]
@REM Example: compile.cmd test.exe
@echo off
set srcExe=app.exe
set dstExe=%1
dotnet publish -c Release --self-contained -o tmp
move tmp\%srcExe% %dstExe%
rmdir /s /q tmp
@echo on