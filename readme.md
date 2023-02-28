clone project using git clone command.<br/><br/>
modify default connection string in appsettings.config and appsettings.development.config in both datamodel and api project "Data Source=<your db server name>;Initial Catalog=imftenantdb;Integrated Security=True; TrustServerCertificate=True.<br/><br/>
open project and restore packages.<br/><br/>
This projct uses EF code first approach which uses migrations.<br/><br/>
In visual studio open Tools--> NuGet Packagemanager --> NuGet Package Manager Console.<br/><br/>
in console run Enable-Migrations -ProjectName datamodel -ContextTypeName imftenant_DbContext.<br/><br/>
once step 6 is complete tum Update-Database, this will create db tables into you db
