using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Courses.Dtos
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course commentModel)
        {
            return new CourseDto
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

        // public static Course ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId)
        // {
        //     return new Course
        //     {
        //         Id = commentModel.Id,
        //         CourseName = commentModel.CourseName,
        //         Department = commentModel.Department,
        //         RegistrationCap = commentModel.RegistrationCap,
        //         Location = commentModel.Location,
        //         StartTime = commentModel.StartTime,
        //         IsOffline = commentModel.IsOffline
        //     };
        // }
    }
}