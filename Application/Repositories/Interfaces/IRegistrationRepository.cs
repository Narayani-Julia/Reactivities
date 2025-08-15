using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Application.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<List<Course>> GetRegisteredCoursesFromStudent(Student student);
        Task<List<Student>> GetRegisteredStudentFromCourse(Course course);
        Task<Registered> CreateAsync(Registered registration);
        //TODO: Why is it symbol and not an id here?
        Task<Registered> DeletePortfolio(Student currentStudent, string CourseName);        
        
    }
}