using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Students.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; } //= Guid.NewGuid().ToString();                
        public required string FirstName { get; set; }
        public required string LastName { get; set; }         
    }
}