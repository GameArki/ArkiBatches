@echo off
set help=Example: GitDownload.cmd url fromDir toDir

@REM Example: GitDownload.cmd ssh://git@github.com/GameArki/FPMath.git Assets\com.gamearki.fpmath FPMath
@REM 如果参数总量不等于3, 输出 help 并退出  
set count=0
for %%a in (%*) do set /a count+=1
if %count% neq 3 (
    echo Args count is not 3!
    echo %help%
    exit /b 1
)

@REM 获取第0个参数
set url=%1
set fromDir=%2
set toDir=%3

set TMPDIR=tttttttmp_repo

@REM git clone %url% %toDir%
git clone %url% %TMPDIR%

@REM 从 %fromDir% 复制到 %toDir%
xcopy %TMPDIR%\%fromDir% %toDir% /E /Y /I /Q

@REM 移除 %TMPDIR%
rmdir /S /Q %TMPDIR%

@echo on
@echo Download %url% to %toDir% success!