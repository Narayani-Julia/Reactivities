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
        public async Task<IActionResult> GetAllCoursesForStudent([FromRoute] int id, string type)
        {
            if (type.ToLower() == "student")
            {
                var student = await studentRepo.GetByIdAsync(id);
                var registeredPortfolio = await registeredRepo.GetRegisteredCoursesFromStudent(student);
                return Ok(registeredPortfolio);
            }
            if (type.ToLower() == "course")
            {
                var course = await courseRepo.GetByIdAsync(id);
                var registeredPortfolio = await registeredRepo.GetRegisteredStudentFromCourse(course);
                return Ok(registeredPortfolio);
            }
            else
            {
                return BadRequest("type can only be Student or Course to specify what id is being sent");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(int studentId, string courseName)
        {
            //
            var course = await courseRepo.GetByCourseNameAsync(courseName);
            var student = await studentRepo.GetByIdAsync(studentId);

            if (student == null) return BadRequest("Student not found");
            if (course == null) return BadRequest("Course not found");

            var newRegistratoin = await registeredRepo.GetRegisteredCoursesFromStudent(student);

            if (newRegistratoin.Any(e => e.CourseName.ToLower() == courseName.ToLower())) return BadRequest("Cannot add same student to class");

            var registeredModel = new Registered
            {
                StudentId = student.Id,
                CourseId = course.Id
            };

            await registeredRepo.CreateAsync(registeredModel);

            if (registeredModel == null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete]
        [Route("{studentId:int}")]
        
        public async Task<IActionResult> DeleteRegistration(int studentId, [FromQuery] string courseName)
        {
            var student = await studentRepo.GetByIdAsync(studentId);
            if (student == null) return BadRequest("No Such student ID");
            else
            {
                var userPortfolio = await registeredRepo.GetRegisteredCoursesFromStudent(student);
                var filteredRegistration = userPortfolio.Where(s => s.CourseName.ToLower() == courseName.ToLower()).ToList();

                if (filteredRegistration.Count() == 1)
                {
                    await registeredRepo.DeletePortfolio(student, courseName);
                }
                else
                {
                    return BadRequest("Student not registered in that course");
                }
                return Ok();
            }
        }

    }
}