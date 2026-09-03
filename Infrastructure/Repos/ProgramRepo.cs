using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class ProgramRepo(AppDbContext context) : IProgramRepo
    {
        public async Task<Program> GetProgramByIdAsync(int programId)
        {
            return await context.Programs
                .Include(p => p.ders)
                .Include(p => p.Personel)
                .Include(p => p.Sinif)
                .FirstOrDefaultAsync(p => p.Program_Id == programId);
        }

        public async Task<List<Program>> GetProgramBySinifIdAsync(int sinifId)
        {
            return await context.Programs
                .Include(p => p.ders)
                .Include(p => p.Personel)
                .Include(p => p.Sinif)
                .Where(p => p.Sinif_id == sinifId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Program>> GetProgramBySinifIdAndDayAsync(int sinifId, Days day)
        {
            return await context.Programs
                .Include(p => p.ders)
                .Include(p => p.Personel)
                .Include(p => p.Sinif)
                .Where(p => p.Sinif_id == sinifId && p.Day == day)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Program>> AddProgramsAsync(List<Program> programs)
        {
            await context.Programs.AddRangeAsync(programs);
            await context.SaveChangesAsync();
            return programs;
        }

        public async Task<Program> UpdateProgramAsync(Program program)
        {
            context.Programs.Update(program);
            await context.SaveChangesAsync();
            return program;
        }

        public async Task<bool> DeleteProgramAsync(int programId)
        {
            var program = await context.Programs.FindAsync(programId);
            if (program == null) return false;

            context.Programs.Remove(program);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProgramsBySinifIdAsync(int sinifId)
        {
            await context.Programs.Where(p => p.Sinif_id == sinifId).ExecuteDeleteAsync();
            return true;
        }

        public async Task<bool> DeleteProgramsBySinifIdAndDayAsync(int sinifId, Days day)
        {
            await context.Programs.Where(p => p.Sinif_id == sinifId && p.Day == day).ExecuteDeleteAsync();
            return true;
        }
    }
}
