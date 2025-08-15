using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Teachers.Dtos;
using Domain;

namespace Application.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> CreateAsync(Teacher stockModel);
        Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto stockDto);
        Task<Teacher?> DeleteAsync(int id);

        // TODO: Do we need to check for TeacherId when we create a Course?
        Task<bool> TeacherExists(int id);        
    }
}