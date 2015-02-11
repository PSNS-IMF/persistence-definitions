@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Definitions.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

REM Unit Tests
%VsTestConsole% test\Definitions.UnitTests\bin\%config%\Definitions.UnitTests.dll
if not "%errorlevel%"=="0" goto failure

mkdir Build
mkdir Build\lib
mkdir Build\lib\net40

%nuget% pack "src\Psns.Common.Persistence.Definitions\nuget\Psns.Common.Persistence.Definitions.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"

:success
exit 0

:failure
exit -1
