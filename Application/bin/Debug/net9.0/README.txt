We APIs:
download c# dev kit extension, material icon theme, nuget gallery by pcislo, SQLite viewer

cmd: dotnet new list //list of different templates you can create using the netline cmd line utility

dotnet new sln 
dotnet new webapi -n API -controllers
//should create a controllers folder, named API
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classily -n Persistance
dotnet sln add API
add Application, add Persistence, add Domain

Step: Add references:
- Solution Explorer
- API - add project reference to Application
- Application add project reference to Domain and Persistence
- Domain has no references
- persistence add project reference to Domain


-in launchSettings.json > remove one of the profiles, and change port number to 5001, and remove the http url. 

cmd-> cd API -> dotnet run
dotnet watch: hot reload, CTRL+R to restart

-remove ItemGroup package reference to OpenApi
- remove API.http file since that you would need an extension for, postman is equivalent to this

-Program.cs
two sections: 
1. adding services
2. http request pipeline:
- for middleware
- remove HttpsRedirection
- for now remove authorization, but it will be used later

- creating domain entity
- go to class1.cs and delete it in domain
- c# dev kit will be used here
- right click domain in Solution Explorer-> new file -> Class
- Activity class file name
- Activity is an Entity
- in file write prop and press tab// creates an autoimplemented property
- entity frameworks need to have public properties

- Stop Terminal Running when you are adding a db into your project
- microsoft.entityframework.SQLite -> select correct version as that of your runtime
-> add it to your persistence
- add design to your API.csproj likewise

- dotnet checks for configurations
- goes into appsettings.json during production
during development mode appsettings.json is what it goes into
- Change MIcrosoft.AspNetCore: to "Information"

-   add to the appsettings.json: 
"ConnectionStrings": {
    "DefaultConnection": "Data source=reactivities.db"
  }
https://www.nuget.org/packages/dotnet-ef/
- dotnet tool install --global dotnet-ef --version 9.0.8

- creating migration entity framework:
dotnet ef migrations add InitialCreate -p ProjectNamePersistance -s starterProjectAPI
- dotnet build
do this so that you know if there are any errors in your code
To apply the migration:
- dotnet ef database update -p Persistance -s API
do this 
same command as above but drop instead of update in order to remove the table you created
