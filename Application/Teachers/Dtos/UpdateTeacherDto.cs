using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Teachers.Dtos
{
    public class UpdateTeacherDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "First Name cannot be over 100 over characters")]

        public required string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Last Name cannot be over 100 over characters")]
        public required string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Dept Name cannot be over 100 over characters")]

        public required string Department { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "OfficeNo cannot be over 100 over characters")]

        public required string OfficeNo { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Email cannot be over 100 over characters")]

        public required string EmailAddress { get; set; } = string.Empty;
    }
}