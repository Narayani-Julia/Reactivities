using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Students.Dtos
{
    public class CreateStudentDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }         
        
    }
}