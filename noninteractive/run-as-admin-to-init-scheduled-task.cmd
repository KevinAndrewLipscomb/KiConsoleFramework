schtasks /end^
 /tn KiConsoleFramework
::
schtasks /delete^
 /tn KiConsoleFramework^
 /f
::
schtasks /create^
 /tn KiConsoleFramework^
 /tr "%~dp0..\KiConsoleFramework\bin\KiConsoleFramework.exe"^
 /sc onstart^
 /np
::
schtasks /run^
 /tn KiConsoleFramework
::
%windir%\system32\taskschd.msc
