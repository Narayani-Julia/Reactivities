using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Repositories
{
    //private readonly AppDbContext _context;
    public class RegistrationRepository(AppDbContext context) : IRegistrationRepository
    {
        public async Task<Registered> CreateAsync(Registered registration)
        {
             await context.Registerations.AddAsync(registration);
             await context.SaveChangesAsync();
             return registration;
        }

        public async Task<Registered> DeletePortfolio(Student currentStudent, string symbol)
        {
            var registrationModel = await context.Registerations.FirstOrDefaultAsync(x => x.StudentId == currentStudent.Id && x.RegisteredCourse.CourseName == symbol);

            if (registrationModel == null)
            {
                return null;
            }

            context.Registerations.Remove(registrationModel);
            await context.SaveChangesAsync();
            return registrationModel;
        }

        public async Task<List<Course>> GetRegisteredCoursesFromStudent(Student student)
        {
            return await context.Registerations.Where(u => u.StudentId == student.Id)
            .Select(regsitered => new Course
            {
                Id = regsitered.CourseId,
                CourseName = regsitered.RegisteredCourse.CourseName,
                Department = regsitered.RegisteredCourse.Department,
                RegistrationCap = regsitered.RegisteredCourse.RegistrationCap,
                Location = regsitered.RegisteredCourse.Location,
                StartTime = regsitered.RegisteredCourse.StartTime,
                IsOffline = regsitered.RegisteredCourse.IsOffline,
            }).ToListAsync();        
        }

        public async Task<List<Student>> GetRegisteredStudentFromCourse(Course course)
        {
            return await context.Registerations.Where(u => u.CourseId == course.Id)
            .Select(regsitered => new Student
            {
                Id = regsitered.StudentId,
                LastName = regsitered.CurrentStudent.LastName,
                FirstName = regsitered.CurrentStudent.FirstName,
            }).ToListAsync();
        }
    }
}