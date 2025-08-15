using Persistance;
using Microsoft.EntityFrameworkCore;
using Application.Activities.Queries;
using Application.Core;
using Application.Repositories.Interfaces;
using Application.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//Make sure to do this before the builder.Build() line
//Pass an option object to the Db so that you can specify the configurations of the DB
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbContext>(opt=>{
    //Pretty standard connection string esp when there is one DB connection string
    //opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//swaggerui
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//CQRS: Command Query
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors();
//If youre doing it the Repository Route:
//builder.Services.AddScoped<IActivitiesRepository, ActivityRepository>();
//NOTE: RegisterServicesFromAssemblyContaining will add the rest of the Handlers if you register one of them. So not to worry
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
//Activities>bin>Application.dll is the assemblies
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<ICoursesRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

//

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app .UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
// A lot of developers use the word x instead of options, so it becomes conventional
 app.UseCors(options =>
 options.AllowAnyHeader().AllowAnyMethod().
 WithOrigins("http://localhost:3000", "https://localhost:3000"));
//Not putting this will not allow swagger to run
 //you;ll get an http redirect error if not
app.MapControllers();

//using does the automatic cleanup for us
//when this function goes outside of scope, anything that is used here is going to be disposed by the framework
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

// try
// {
//     //TODO: Check MigrateAsync use
//     //seed the data into the db here
//     var context = services.GetRequiredService<AppDbContext>();
//     //basically is equivalent to dotnet update
//     //still need to run dotnet watch to run the thing though
//     await context.Database.MigrateAsync();
//     //await DbInitializer.SeedData(context);
// }
// catch (Exception ex)
// {
//     var logger = services.GetRequiredService<ILogger<Program>>();
//     logger.LogError(ex, "An error occured during migration");
// }

app.Run();
