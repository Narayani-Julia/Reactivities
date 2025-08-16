using System;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistance;
//Need to derive from an entity framework class to use this

//DbContext is made up of Repository and Unit of Work patterns, Unit of Work is harder to create a mock for when you are testing
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    //TODO: Is constructor overriden
    //referencing the entities we created here
    //db should not be null
    //grab something from tables and creates the db for us
    public required DbSet<Activity> Activities { get; set; }
    public required DbSet<Student> Students { get; set; }
    public required DbSet<Course> Courses { get; set; }
    public required DbSet<Teacher> Teachers { get; set; }
    public required DbSet<Registered> Registerations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Registered>(x => x.HasKey(p => new { p.StudentId, p.CourseId }));

            builder.Entity<Registered>()
                .HasOne(u => u.CurrentStudent)
                .WithMany(u => u.RegisteredCourses)
                .HasForeignKey(p => p.StudentId);

            builder.Entity<Registered>()
                .HasOne(u => u.RegisteredCourse)
                .WithMany(u => u.RegisteredStudents)
                .HasForeignKey(p => p.CourseId);
        }

}
