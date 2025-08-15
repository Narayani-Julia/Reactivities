using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Students.Dtos
{
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(80, ErrorMessage = "CourseName cannot be over 80 over characters")]
        public required string CourseName { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Department cannot be over 80 over characters")]
        public required string Department { get; set; }
        [Required]
        [Range(1, 400)]
        public int RegistrationCap  { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Location cannot be over 80 over characters")]
        public required string Location { get; set; }
        [Required]
        public DateTime StartTime  { get; set; }
        [Required]
        public bool IsOffline { get; set; }

        //One Course - Many Teachers
        public int? TeacherId { get; set; }

    }
}