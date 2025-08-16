using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Teachers.Dtos
{
    public class CreateTeacherDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Department { get; set; }
        public required string OfficeNo { get; set; }
        public required string EmailAddress { get; set; }        
    }
}