using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RegisteredController(ICoursesRepository courseRepo, IStudentRepository studentRepo, IRegistrationRepository registeredRepo) : BaseApiController
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCoursesForStudent([FromRoute] int id)
        {
            var student = await studentRepo.GetByIdAsync(id); 
            var userPortfolio = await registeredRepo.GetRegisteredCoursesFromStudent(student);
            return Ok(userPortfolio);
        }

        // Matching http get requests
        // [HttpGet("{id:int}")]
        // public async Task<IActionResult> GetAllStudentsForCourse([FromRoute] int id)
        // {
        //     var course = await courseRepo.GetByIdAsync(id); 
        //     var userPortfolio = await registeredRepo.GetRegisteredStudentFromCourse(course);
        //     return Ok(userPortfolio);
        // }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(int studentId, string courseName)
        {
            var course = await courseRepo.GetByCourseNameAsync(courseName);
            var student = await studentRepo.GetByIdAsync(studentId);

            if (student == null) return BadRequest("Student not found");
            if (course == null) return BadRequest("Course not found");

            var newRegistratoin = await registeredRepo.GetRegisteredCoursesFromStudent(student);

            if (newRegistratoin.Any(e => e.CourseName.ToLower() == courseName.ToLower())) return BadRequest("Cannot add same student to class");

            var portfolioModel = new Registered
            {
                StudentId = student.Id,
                CourseId = course.Id
            };

            await registeredRepo.CreateAsync(portfolioModel);

            if (portfolioModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        
        public async Task<IActionResult> DeleteRegistration(int studentId, [FromQuery] string courseName)
        {
            var student = await studentRepo.GetByIdAsync(studentId);
            if (student == null) return BadRequest("No Such student ID");
            else
            {
                var userPortfolio = await registeredRepo.GetRegisteredCoursesFromStudent(student);
                var filteredStock = userPortfolio.Where(s => s.CourseName.ToLower() == courseName.ToLower()).ToList();

                if (filteredStock.Count() == 1)
                {
                    await registeredRepo.DeletePortfolio(student, courseName);
                }
                else
                {
                    return BadRequest("Stock not in your portfolio");
                }
                return Ok();
            }
        }

    }
}