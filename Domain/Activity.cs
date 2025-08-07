using System;
namespace Domain;

public class Activity
{
    //by Default Id is gonna be the primary key of an entity framework
    //Strings are easier to work with then Guid data types
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title {get; set;}
    public DateTime Date {get; set;}
    public required string Description {get; set;}
    public required string Category {get; set;}
    public bool IsCancelled {get; set;}
    public required string City {get; set;}
    public required string Venue {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
}
