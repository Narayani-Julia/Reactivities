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

        public static Course ToCommentFromCreate(this CreateCommentDto commentModel, int stockId)
        {
            return new Course
            {
                Id = commentModel.Id,
                CourseName = commentModel.CourseName,
                Department = commentModel.Department,
                RegistrationCap = commentModel.RegistrationCap,
                Location = commentModel.Location,
                StartTime = commentModel.StartTime,
                IsOffline = commentModel.IsOffline
            };
        }

        public static Course ToCommentFromUpdate(this UpdateCommentRequestDto commentModel, int stockId)
        {
            return new Course
            {
                Id = commentModel.Id,
                CourseName = commentModel.CourseName,
                Department = commentModel.Department,
                RegistrationCap = commentModel.RegistrationCap,
                Location = commentModel.Location,
                StartTime = commentModel.StartTime,
                IsOffline = commentModel.IsOffline
            };
        }    }
}