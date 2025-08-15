using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Teacher
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Department { get; set; }
        public required string OfficeNo { get; set; }
        public required string EmailAddress { get; set; }

        public List<Course> TaughtCourses { get; set; } = new List<Course>();

    }
}