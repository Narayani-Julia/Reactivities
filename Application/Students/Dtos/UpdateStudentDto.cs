using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Students.Dtos
{
    public class UpdateStudentDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be over 100 over characters")]
        public required string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Last Name cannot be over 100 over characters")]
        public required string LastName { get; set; } = string.Empty;     

    }
}