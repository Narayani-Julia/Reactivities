using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Application.Students.Dtos;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Repositories
{
    public class CoursesRepository(AppDbContext context) : ICoursesRepository
    {
        public async Task<Course> CreateAsync(Course courseModel)
        {
            await context.Courses.AddAsync(courseModel);
            await context.SaveChangesAsync();
            return courseModel;
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            var courseModel = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (courseModel == null)
            {
                return null;
            }
            context.Courses.Remove(courseModel);
            await context.SaveChangesAsync();
            return courseModel;        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await context.Courses.Include(a => a.AssignedTeacher).ToListAsync();
        }

        public async Task<Course?> GetByCourseNameAsync(string courseName)
        {
            return await context.Courses.Include(a => a.AssignedTeacher).FirstOrDefaultAsync(c => c.CourseName == courseName);
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await context.Courses.Include(a => a.AssignedTeacher).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> UpdateAsync(int id, UpdateCourseDto commentMode)
        {
            var existingComment = await context.Courses.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }
            existingComment.TeacherId = commentMode.TeacherId;
            existingComment.CourseName = commentMode.CourseName;
            existingComment.Department = commentMode.Department;
            existingComment.RegistrationCap = commentMode.RegistrationCap;
            existingComment.Location = commentMode.Location;
            existingComment.StartTime = commentMode.StartTime;
            existingComment.IsOffline = commentMode.IsOffline;
            await context.SaveChangesAsync();
            return existingComment;
        }        
    }
}