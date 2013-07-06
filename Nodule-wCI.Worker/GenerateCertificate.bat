@ECHO OFF
@rem Check for visual studio tools if not already loaded
if defined VCINSTALLDIR goto GenerateCert
@rem Ensure that visual studio is available
if not defined VS110COMNTOOLS goto msbuild-not-found
if not exist "%VS110COMNTOOLS%..\..\vc\vcvarsall.bat" goto msbuild-not-found
call "%VS110COMNTOOLS%..\..\vc\vcvarsall.bat"
@rem Check that vs is properly loaded
if not defined VCINSTALLDIR goto msbuild-not-found

:GenerateCert
@REM Delete previous one
del /F Nodule-wCI-WorkerService.pfx
@REM Try to export existing certificate
certutil.exe -user -privatekey -exportpfx "Nodule-wCI-WorkerService" Nodule-wCI-WorkerService.pfx
if %errorlevel% EQU 0 goto Finish
echo Certificate not found. Generating a new one...
@REM Else, if not found
@REM Generate a long lasting certificate (20 years from now)
@REM Get current date
for /F "tokens=1* delims= " %%A in ('date /T') do set CDATE=%%B
@REM we don't actually care if it's MM or DD as we will place them in the same order
for /F "tokens=1,2 eol=/ delims=/ " %%A in ('date /T') do set dd=%%B
for /F "tokens=1,2 delims=/ eol=/" %%A in ('echo %CDATE%') do set mm=%%B
for /F "tokens=2,3 delims=/ " %%A in ('echo %CDATE%') do set yyyy=%%B

@REM Add 20 years
SET /A yyyy=%yyyy%+20

@REM Generate certificate
makecert -r -pe -n "CN=Nodule-wCI-WorkerService" -e %dd%/%mm%/%yyyy% -ss my -sr currentuser -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12  

@REM Export to deliver with the calling website
certutil.exe -user -privatekey -exportpfx "Nodule-wCI-WorkerService" Nodule-wCI-WorkerService.pfx

:Finish
echo Install the generated certificate in your 'LocalMachine' Personal certificates.
echo done. Press any key to exit
pause
exit /B 0

:msbuild-not-found
echo Visual studio tools were not found! Please check the VS110COMNTOOLS path variable
exit /B 1