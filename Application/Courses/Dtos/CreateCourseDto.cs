using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Courses.Dtos
{
    public class CreateCourseDto
    {
        public required string CourseName  { get; set; } = string.Empty;
        public required string Department { get; set; } = string.Empty;
        public int RegistrationCap  { get; set; }
        public required string Location { get; set; } = string.Empty;
        public DateTime StartTime  { get; set; }
        public bool IsOffline { get; set; }

    }
}