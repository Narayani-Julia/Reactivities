using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Courses.Dtos;
using Application.Repositories.Interfaces;
using Application.Students.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers
{
    public class CoursesController(ITeacherRepository teacherRepo, ICoursesRepository courseRepo) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var courses = await courseRepo.GetAllAsync();
            var courseDto = courses.Select(s => s.ToCourseDto()).ToList();
            return Ok(courseDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var course = await courseRepo.GetByIdAsync(id);
            if (course == null) {
                return NotFound(); }
            return Ok(course.ToCourseDto());
        }

        [HttpPost]
        [Route("{teacherId:int}")]
        public async Task<IActionResult> Create([FromRoute] int teacherId, CreateCourseDto courseDto)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState); }
            if (!await teacherRepo.TeacherExists(teacherId)) {
                return BadRequest("Teacher does not exist"); }
            var courseModel = courseDto.ToCourseFromCreate(teacherId);
            await courseRepo.CreateAsync(courseModel);
            return CreatedAtAction(nameof(GetById), new { id = courseModel.Id }, courseModel.ToCourseDto());
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var course = await courseRepo.UpdateAsync(id, updateDto);
            if (course == null) {
                return NotFound("Course not found"); }
            return Ok(course.ToCourseDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseModel = await courseRepo.DeleteAsync(id);

            if (courseModel == null)
            {
                return NotFound("Course does not exist");
            }

            return Ok(courseModel);
        }
    }
}