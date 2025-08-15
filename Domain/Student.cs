using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();                
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<Registered> RegisteredCourses { get; set; } = new List<Registered>();
    }
}