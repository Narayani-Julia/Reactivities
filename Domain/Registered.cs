using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Registered")]
    public class Registered
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Student CurrentStudent { get; set; }
        public Course RegisteredCourse { get; set; }
    }
}