using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Students.Dtos
{
    public static class StudentMapper
    {
        public static StudentDto ToStudentDto(this Student commentModel)
        {
            return new StudentDto
            {
                Id = commentModel.Id,
                LastName = commentModel.LastName,
                FirstName = commentModel.FirstName
            };
        }

        public static Student ToStudentFromCreate(this CreateStudentDto commentModel)
        {
            return new Student
            {
                LastName = commentModel.LastName,
                FirstName = commentModel.FirstName,
            };
        }

        public static Student ToStudentFromUpdate(this UpdateStudentDto commentModel)
        {
            return new Student
            {
                LastName = commentModel.LastName,
                FirstName = commentModel.FirstName,
            };
        }
    }    
}