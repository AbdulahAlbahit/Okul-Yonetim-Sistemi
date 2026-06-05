using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repos
{
    public class ProgramRepo(AppDbContext context) : IProgramRepo
    {
        public async Task<List<Program>> AddProgramAsync(List<Program> program)
        {
            context.Programs.AddRange(program);
            await context.SaveChangesAsync();
            return program;
        }

        public async Task<bool> DeleteListProgramAsync(List<Program> programs)
        {
            context.Programs.RemoveRange(programs);
           
                await    context.SaveChangesAsync();
            return true;
        }

        public Task<TimeOnly> GetDateOfDersByDersName(Days day, string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDersNameByTimeAsync(Days day, TimeOnly time)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Program>> GetProgramAsync(int Sinif_id)
        {
            var program=await context.Programs.Where(a=>a.Sinif_id == Sinif_id) .AsNoTracking().ToListAsync();
            return program;
        }

        public async Task<List<Program>> GetProgramByDayAsync(Days day, int Sinif_id)
        {
            var program = await context.Programs.Where(a => a.Day == day && a.Sinif_id == Sinif_id).AsNoTracking().ToListAsync() ;
            return program ;
        }

        public async Task<List<Program>> UpdateProgram(List<Program> program)
        {
            context.Programs.UpdateRange(program);
            await context.SaveChangesAsync();
            return program;
        }

        public Task<Program> UpdateProgramAtDate(Program program, Days Day)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Program>> UpdateProgramAtDate(List<Program> program)
        {
                       context.Programs.UpdateRange(program);
                       await context.SaveChangesAsync(); 
                         return program;
        }
    }
}
