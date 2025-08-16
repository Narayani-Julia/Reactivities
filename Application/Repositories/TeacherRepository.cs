using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.Interfaces;
using Application.Teachers.Dtos;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Repositories
{
    public class TeacherRepository(AppDbContext context) : ITeacherRepository
    {
        public async Task<Teacher> CreateAsync(Teacher stockModel)
        {
            await context.Teachers.AddAsync(stockModel);
            await context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Teacher?> DeleteAsync(int id)
        {
            var stockModel = await context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            context.Teachers.Remove(stockModel);
            await context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var Teachers = context.Teachers.Include
            (c => c.TaughtCourses).AsQueryable();
            return await Teachers.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await context.Teachers.Include(c => c.TaughtCourses).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> TeacherExists(int id)
        {
            return context.Teachers.AnyAsync(s => s.Id == id);
        }

        public async Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto teacherDto)
        {
            var existingStock = await context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.FirstName = teacherDto.FirstName;
            existingStock.LastName = teacherDto.LastName;
            existingStock.OfficeNo = teacherDto.OfficeNo;
            existingStock.Department = teacherDto.Department;
            existingStock.EmailAddress = teacherDto.EmailAddress;

            await context.SaveChangesAsync();

            return existingStock;        }
    }
}