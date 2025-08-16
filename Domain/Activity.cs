using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain;

[Table("Activities")]
public class Activity
{
    //by Default Id is gonna be the primary key of an entity framework
    //Strings are easier to work with then Guid data types
    //TODO: Figure how this is being set this to the primary key
    public int Id { get; set; } //= Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }
    public required string City { get; set; }
    public required string Venue { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }



    //DTO: if multiple teachers: ActModel.Teacher.Select(c->c.ToTeacherDto()).ToList();
    //
    //public int TeacherId { get; set; }
    // Don't include this in the DTO apparently
    //public Teacher AssignedTeacher { get; set; }
}
