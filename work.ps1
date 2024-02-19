Set-Location 'C:\Users\KevinAndrewLipscomb\Documents\SANDBOX\vocational\kalipso-infogistics\OWNREPO\KiConsoleFramework'
Start-Process -WindowStyle Maximized 'C:\Users\KevinAndrewLipscomb\Documents\SANDBOX\vocational\kalipso-infogistics\OWNREPO\KiConsoleFramework'
Start-Process -WindowStyle Maximized KiConsoleFramework.sln
IF (Test-Path 'C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe')
  {
  Start-Process -WindowStyle Maximized 'C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe'
  }
ELSE
  {
  Start-Process -WindowStyle Maximized 'C:\Program Files (x86)\MySQL\MySQL Workbench\MySQLWorkbench.exe'
  }
