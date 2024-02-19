# Derived from KiZeroBuild/0build.cmd
#
# Remove unneeded lines.
#
Set-Variable bash "C:\cygwin\bin\bash"
Set-Variable cyg "/cygdrive/c/cygwin/bin"
Write-Output ""
Write-Output "*"
Write-Output "* Make sure any instance of Visual Studio that has touched KiConsoleFramework.sln has been shut down."
Write-Output "*"
Pause
Write-Output ""
Write-Output "OPERATING AT LOCAL ENVIRONMENT LEVEL..."
Write-Output ""
Write-Output "-- Running dotnet nuget locals all --clear"
Write-Output ""
dotnet nuget locals all --clear
Write-Output ""
Set-Variable CommonCommandStartForFolders "$bash -c '$cyg/find -depth -name"
Set-Variable CommonCommandEndForFolders "-type d -exec $cyg/rm --recursive {} \;'"
Write-Output ""
Write-Output "OPERATING AT SOLUTION LEVEL..."
Write-Output ""
Write-Output "-- Removing solution's .vs folder(s)..."
Invoke-Expression "$CommonCommandStartForFolders .vs $CommonCommandEndForFolders"
Write-Output "-- Removing solution's bin folder(s)..."
Invoke-Expression "$CommonCommandStartForFolders bin $CommonCommandEndForFolders"
Write-Output "-- Removing solution's node_modules folder(s)..."
Invoke-Expression "$CommonCommandStartForFolders node_modules $CommonCommandEndForFolders"
Write-Output "-- Removing solution's obj folder(s)..."
Invoke-Expression "$CommonCommandStartForFolders obj $CommonCommandEndForFolders"
Write-Output "-- Removing solution's packages folder(s)..."
Invoke-Expression "$CommonCommandStartForFolders packages $CommonCommandEndForFolders"
Write-Output "-- Removing solution's *.*proj.user file(s)..."
Invoke-Expression "$bash -c '$cyg/find -name *.*proj.user -type f -exec $cyg/rm {} \;'"
Write-Output ""
Write-Output "DESCENDING INTO PROJECT App..."
Push-Location KiConsoleFramework
Write-Output ""
Write-Output "When you are ready to manually remove the configuration/runtime element from App.config,"
Pause
Invoke-Item App.config
Write-Output ""
Write-Output "Confirm that you have removed the configuration/runtime element from App.config,"
Pause
Write-Output ""
Write-Output "-- Running npm install..."
Write-Output ""
npm install --no-fund
Write-Output ""
Write-Output "RETURNING TO SOLUTION LEVEL..."
Pop-Location
Write-Output ""
Write-Output "-- Running nuget restore..."
Write-Output ""
nuget restore
Write-Output ""
Write-Output "*"
Write-Output "* KiConsoleFramework.sln will now open in Visual Studio. Manually launch a Build, then perform the recommended runtime"
Write-Output "* assemblyBinding redirect procedure, if any."
Write-Output "*"
Pause
Invoke-Item KiConsoleFramework.sln
Write-Output ""
Write-Output "*"
Write-Output "* Put any configuration/runtime element changes into controlled instances of App.config as applicable."
Write-Output "*"
Pause
