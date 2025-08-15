using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Courses.Dtos;
using Domain;

namespace Application.Teachers.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Department { get; set; }
        public required string OfficeNo { get; set; }
        public required string EmailAddress { get; set; }

        //One to Many
        public List<CourseDto> TaughtCourses { get; set; }        
 
    }
}