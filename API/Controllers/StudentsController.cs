using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Application.Students.Dtos;
using Microsoft.AspNetCore.Mvc;
using Persistance;

namespace API.Controllers
{
    public class StudentsController(IStudentRepository studentRepo, AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = await studentRepo.GetAllAsync();
            var studentDto = students.Select(s => s.ToStudentDto()).ToList();
            return Ok(studentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var student = await studentRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student.ToStudentDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var studentModel = studentDto.ToStudentFromCreate();
            await studentRepo.CreateAsync(studentModel);
            return CreatedAtAction(nameof(GetById), new { id = studentModel.Id }, studentModel.ToStudentDto());
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStudentDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var studentModel = await studentRepo.UpdateAsync(id, updateDto);
            if (studentModel == null)
            {
                return NotFound("Student Not Found");
            }
            return Ok(studentModel.ToStudentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var studentModel = await studentRepo.DeleteAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }
            
            return Ok(studentModel);
        }
    }
}