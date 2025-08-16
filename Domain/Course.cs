using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();        
        public required string CourseName  { get; set; }
        public required string Department { get; set; }
        public int RegistrationCap  { get; set; }
        public required string Location { get; set; }
        public DateTime StartTime  { get; set; }
        public bool IsOffline { get; set; }

        //Many Course - One Teachers
        public int? TeacherId { get; set; }
        public Teacher AssignedTeacher { get; set; }

        //Many - To - Many relationship
        public List<Registered> RegisteredStudents { get; set; } = new List<Registered>();

    }
}