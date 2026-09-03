using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class SinavRepo(AppDbContext context) : ISinavRepo
    {
        public async Task<List<Sinav>> GetAllSinavAsync()
        {
            return await context.Sinavs
                .Include(a => a.ders)
                .Include(a => a.personel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Sinav> GetSinavByIdAsync(int id)
        {
            var sinav = await context.Sinavs
                .Include(a => a.ders)
                .Include(a => a.personel)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Sinav_Id == id);

            if (sinav != null)
                return sinav;

            return new Sinav();
        }

        public async Task<List<Sinav>> GetSinavlarByDersIdAsync(int dersId)
        {
            return await context.Sinavs
                .Include(a => a.ders)
                .Include(a => a.personel)
                .Where(a => a.Ders_Id == dersId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Sinav>> GetSinavlarByHocaIdAsync(int hocaId)
        {
            return await context.Sinavs
                .Include(a => a.ders)
                .Include(a => a.personel)
                .Where(a => a.Hoca_Id == hocaId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Sinav> AddSinavAsync(Sinav sinav)
        {
            await context.Sinavs.AddAsync(sinav);
            await context.SaveChangesAsync();
            return sinav;
        }

        public async Task<Sinav> UpdateSinavAsync(Sinav sinav)
        {
            context.Sinavs.Update(sinav);
            await context.SaveChangesAsync();
            return sinav;
        }

        public async Task<bool> DeleteSinavAsync(int id)
        {
            var sinav = await context.Sinavs.FirstOrDefaultAsync(a => a.Sinav_Id == id);
            if (sinav == null)
                return false;

            context.Sinavs.Remove(sinav);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
