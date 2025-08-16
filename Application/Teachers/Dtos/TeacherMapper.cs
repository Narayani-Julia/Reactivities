using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Courses.Dtos;
using Domain;

namespace Application.Teachers.Dtos
{
    public static class TeacherMapper
    {
        public static TeacherDto ToTeacherDto(this Teacher commentModel)
        {
            return new TeacherDto
            {
                Id = commentModel.Id,
                FirstName = commentModel.FirstName,
                LastName = commentModel.LastName,
                Department = commentModel.Department,
                OfficeNo = commentModel.OfficeNo,
                EmailAddress = commentModel.EmailAddress,
                TaughtCourses = commentModel.TaughtCourses.Select(c=>c.ToCourseDto()).ToList()
            };
        }

        public static Teacher ToTeacherFromCreate(this CreateTeacherDto commentModel)
        {
            return new Teacher
            {
                FirstName = commentModel.FirstName,
                LastName = commentModel.LastName,
                Department = commentModel.Department,
                OfficeNo = commentModel.OfficeNo,
                EmailAddress = commentModel.EmailAddress,
            };
        }

        public static Teacher ToTeacherFromUpdate(this UpdateTeacherDto commentModel)
        {
            return new Teacher
            {
                FirstName = commentModel.FirstName,
                LastName = commentModel.LastName,
                Department = commentModel.Department,
                OfficeNo = commentModel.OfficeNo,
                EmailAddress = commentModel.EmailAddress,
            };
        }        
    }
}