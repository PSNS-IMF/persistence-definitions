@echo Off

%MsBuildExe% MyGetBuild.proj /p:Configuration="%Configuration%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

REM Unit Tests
"%VsTestConsole%" test\Definitions.UnitTests\bin\%Configuration%\Definitions.UnitTests.dll
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1
