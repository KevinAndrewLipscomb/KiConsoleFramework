# Derived from KiZeroBuild/0build.cmd
#
# Remove unneeded lines.
#
Write-Host ""
Write-Host "*"
Write-Host "* Make sure any instance of Visual Studio that has touched KiConsoleFramework.sln has been shut down."
Write-Host "*"
Pause
Write-Host ""
Write-Host "OPERATING AT LOCAL ENVIRONMENT LEVEL..."
Write-Host ""
Write-Host "-- Running dotnet nuget locals all --clear"
Write-Host ""
& dotnet nuget locals all --clear
Write-Host ""
Write-Host "OPERATING AT SOLUTION LEVEL..."
Write-Host ""
$derivedFolders =
  ".vs",
  "bin",
  "node_modules",
  "obj",
  "packages"
foreach ($derivedFolder in $derivedFolders)
  {
  Write-Host -NoNewLine "-- Removing solution's $derivedFolder folder(s)..."
  if (Test-Path $derivedFolder)
    {
    Remove-Item $derivedFolder -Recurse -Force
    }
  Write-Host "DONE."
  }
$derivedFiles =
  "*.*proj.user"
foreach ($derivedFile in $derivedFiles)
  {
  Write-Host -NoNewLine "-- Removing solution's $derivedFile file(s)..."
  if (Test-Path .vs)
    {
    Remove-Item *.*proj.user -Recurse -Force
    }
  Write-Host "DONE".
  }
Write-Host ""
Write-Host "DESCENDING INTO PROJECT App..."
Push-Location KiConsoleFramework
Write-Host ""
Write-Host "When you are ready to manually remove the configuration/runtime element from App.config,"
Pause
Invoke-Item App.config
Write-Host ""
Write-Host "Confirm that you have removed the configuration/runtime element from App.config,"
Pause
if (Test-Path package.json)
  {
  Write-Host ""
  Write-Host "-- Running npm install..."
  Write-Host ""
  npm install --no-fund
  }
Write-Host ""
Write-Host "RETURNING TO SOLUTION LEVEL..."
Pop-Location
Write-Host ""
Write-Host "-- Running nuget restore..."
Write-Host ""
nuget restore
Write-Host ""
Write-Host "*"
Write-Host "* KiConsoleFramework.sln will now open in Visual Studio. Manually launch a Build, then perform the recommended runtime"
Write-Host "* assemblyBinding redirect procedure, if any."
Write-Host "*"
Pause
Invoke-Item KiConsoleFramework.sln
Write-Host ""
Write-Host "*"
Write-Host "* Put any configuration/runtime element changes into controlled instances of App.config as applicable."
Write-Host "*"
Pause
