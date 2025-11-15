# .NET 10.0 Upgrade Report

## Project target framework modifications

| Project name                                   | Old Target Framework           | New Target Framework    | Commits                              |
|:-----------------------------------------------|:------------------------------:|:-----------------------:|--------------------------------------|
| VMS.vbproj                                     | net8.0-windows10.0.17763.0     | net10.0-windows         | 0f3a174f                             |

## NuGet Packages

| Package Name                        | Old Version | New Version | Commit Id                                 |
|:------------------------------------|:-----------:|:-----------:|-------------------------------------------|
| Microsoft.Data.Sqlite               | 9.0.10      | 10.0.0      | fde082f9                                  |

## All commits

| Commit ID              | Description                                                                                                                                                  |
|:-----------------------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 4f109a19               | Commit upgrade plan                                                                                                                                          |
| 0f3a174f               | Update VMS.vbproj to target .NET 10.0 for Windows                                                                                                            |
| fde082f9               | Update Microsoft.Data.Sqlite to v10.0.0 in VMS.vbproj                                                                                                        |

## Next steps

- Review and test the upgraded project to ensure all functionality works as expected with .NET 10.0
- Consider reviewing any deprecated APIs or breaking changes introduced in .NET 10.0
- Run comprehensive tests to validate the upgrade
