using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Courses.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();        
        public required string CourseName  { get; set; } = string.Empty;
        public required string Department { get; set; } = string.Empty;
        public int RegistrationCap  { get; set; }
        public required string Location { get; set; } = string.Empty;
        public DateTime StartTime  { get; set; }
        public bool IsOffline { get; set; }

        //One Course - Many Teachers
        public int? TeacherId { get; set; }

        // NO NEED TO KEEP THISMany - To - Many relationship
        // public List<Registered> RegisteredStudents { get; set; } = new List<Registered>();

        //Many to One relationship:
        //public string addedDataFromOtherComponent { get; set; } = string.Empty;
    }
}