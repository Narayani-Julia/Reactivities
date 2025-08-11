using Persistance;
using Microsoft.EntityFrameworkCore;
using Application.Activities.Queries;
using Application.Core;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Pass an option object to the Db so that you can specify the configurations of the DB
builder.Services.AddDbContext<AppDbContext>(opt=>{
    //Pretty standard connection string esp when there is one DB connection string
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
//Activities>bin>Application.dll is the assemblies
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
// A lot of developers use the word x instead of options, so it becomes conventional
 app.UseCors(options =>
 options.AllowAnyHeader().AllowAnyMethod().
 WithOrigins("http://localhost:3000", "https://localhost:3000"));
app.MapControllers();

//using does the automatic cleanup for us
//when this function goes outside of scope, anything that is used here is going to be disposed by the framework
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    //seed the data into the db here
    var context = services.GetRequiredService<AppDbContext>();
    //basically is equivalent to dotnet update
    //still need to run dotnet watch to run the thing though
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}
app.Run();
