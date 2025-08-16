using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Students.Dtos;
using Domain;

namespace Application.Courses.Dtos
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                Id = courseModel.Id,
                CourseName = courseModel.CourseName,
                Department = courseModel.Department,
                RegistrationCap = courseModel.RegistrationCap,
                Location = courseModel.Location,
                StartTime = courseModel.StartTime,
                IsOffline = courseModel.IsOffline,
                TeacherId = courseModel.TeacherId
            };
        }

        public static Course ToCourseFromCreate(this CreateCourseDto courseModel, int teacherId)
        {
            return new Course
            {
                CourseName = courseModel.CourseName,
                Department = courseModel.Department,
                RegistrationCap = courseModel.RegistrationCap,
                Location = courseModel.Location,
                StartTime = courseModel.StartTime,
                IsOffline = courseModel.IsOffline,
                TeacherId = teacherId
            };
        }

        public static Course ToCourseFromUpdate(this UpdateCourseDto commentDto, int teacherId)
        {
            return new Course
            {
                CourseName = commentDto.CourseName,
                Department = commentDto.Department,
                RegistrationCap = commentDto.RegistrationCap,
                Location = commentDto.Location,
                StartTime = commentDto.StartTime,
                IsOffline = commentDto.IsOffline,
                TeacherId = commentDto.TeacherId
            };
        }
    }
}