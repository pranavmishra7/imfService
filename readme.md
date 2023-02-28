clone project using git clone command.
modify default connection string in appsettings.config and appsettings.development.config in both datamodel and api project "Data Source=<your db server name>;Initial Catalog=imftenantdb;Integrated Security=True; TrustServerCertificate=True.
open project and restore packages.
This projct uses EF code first approach which uses migrations.
In visual studio open Tools--> NuGet Packagemanager --> NuGet Package Manager Console.
in console run Enable-Migrations -ProjectName datamodel -ContextTypeName imftenant_DbContext.
once step 6 is complete tum Update-Database, this will create db tables into you db
