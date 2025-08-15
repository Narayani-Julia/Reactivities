using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Students.Dtos;
using Domain;

namespace Application.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        //For getting single http request
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student stockModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentDto stockDto);
        Task<Student?> DeleteAsync(int id);
        
 
        //for many to many
        Task<Student?> GetByStudentNameAsync(string studentFirstName);
    }
}