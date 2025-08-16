using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Students.Dtos;
using Domain;

namespace Application.Repositories.Interfaces
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<Course> CreateAsync(Course stockModel);
        Task<Course?> UpdateAsync(int id, UpdateCourseDto stockDto);
        Task<Course?> DeleteAsync(int id);

        //In order to create the Many-To-Many relationship
        //TODO: remove the string matching
        Task<Course?> GetByCourseNameAsync(string courseName);

    }
}