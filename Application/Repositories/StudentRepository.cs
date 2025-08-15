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
    public class StudentRepository(AppDbContext context) : IStudentRepository
    {
        public async Task<Student> CreateAsync(Student stockModel)
        {
            await context.Students.AddAsync(stockModel);
            await context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var stockModel = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            context.Students.Remove(stockModel);
            await context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var stocks = context.Students.Include(a => a.RegisteredCourses).AsQueryable();

            // if (!string.IsNullOrWhiteSpace(query.CompanyName))
            // {
            //     stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            // }

            // if (!string.IsNullOrWhiteSpace(query.Symbol))
            // {
            //     stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            // }

            // if (!string.IsNullOrWhiteSpace(query.SortBy))
            // {
            //     if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
            //     {
            //         stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
            //     }
            // }
            // var skipNumber = (query.PageNumber - 1) * query.PageSize;
            // return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            return await stocks.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await context.Students.Include(c => c.RegisteredCourses).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Student?> GetByStudentNameAsync(string studentName)
        {
            return await context.Students.FirstOrDefaultAsync(s => s.FirstName == studentName);
        }

        public async Task<Student?> UpdateAsync(int id, UpdateStudentDto stockDto)
        {
            var existingStock = await context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null;
            }

            existingStock.FirstName = stockDto.FirstName;
            existingStock.LastName = stockDto.LastName;
            await context.SaveChangesAsync();
            return existingStock;
        }
    }
}