@rem @ECHO OFF
@rem Ask user for host name
SET /P hostName=Host name:

@rem Check for visual studio tools if not already loaded
if defined VCINSTALLDIR goto GenerateCert
@rem Ensure that visual studio is available
if not defined VS110COMNTOOLS goto msbuild-not-found
if not exist "%VS110COMNTOOLS%..\..\vc\vcvarsall.bat" goto msbuild-not-found
call "%VS110COMNTOOLS%..\..\vc\vcvarsall.bat"
@rem Check that vs is properly loaded
if not defined VCINSTALLDIR goto msbuild-not-found

:GenerateCert
makecert -pe -n "CN=%hostName%" -ss my -sr LocalMachine -a sha1 -sky exchange -eku 1.3.6.1.5.5.7.3.1 -in "Nodule-wCI-WorkerService" -is MY -ir LocalMachine -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12

echo done. Press any key to exit
pause
exit /B 0

:msbuild-not-found
echo Visual studio tools were not found! Please check the VS110COMNTOOLS path variable
exit /B 1