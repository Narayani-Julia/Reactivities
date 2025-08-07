using System;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistance;
//Need to derive from an entity framework class to use this

//DbContext is made up of Repository and Unit of Work patterns, Unit of Work is harder to create a mock for when you are testing
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    //referencing the entities we created here
    //db should not be null
    public required DbSet<Activity> Activities { get; set; }
}
