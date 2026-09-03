using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class OgrenciRepo(AppDbContext context) : IOgrenciRepo
    {
        public async Task<List<Ogrenci>> GetAllOgrenciAsync()
        {
            return await context.Ogrencis
                .Include(a => a.sinif)
                .Include(a => a.veli)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ogrenci> GetOgrenciByIdAsync(int id)
        {
            var ogrenci = await context.Ogrencis
                .Include(a => a.sinif)
                .Include(a => a.veli)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (ogrenci != null)
                return ogrenci;

            return new Ogrenci();
        }

        public async Task<Ogrenci> GetOgrenciByNoAsync(string ogrenciNo)
        {
            var ogrenci = await context.Ogrencis
                .Include(a => a.sinif)
                .Include(a => a.veli)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Ogrenci_No == ogrenciNo);

            if (ogrenci != null)
                return ogrenci;

            return new Ogrenci();
        }

        public async Task<List<Ogrenci>> GetOgrencilerBySinifIdAsync(int sinifId)
        {
            return await context.Ogrencis
                .Include(a => a.sinif)
                .Include(a => a.veli)
                .Where(a => a.Sinif_Id == sinifId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ogrenci> AddOgrenciAsync(Ogrenci ogrenci)
        {
            await context.Ogrencis.AddAsync(ogrenci);
            await context.SaveChangesAsync();
            return ogrenci;
        }

        public async Task<Ogrenci> UpdateOgrenciAsync(Ogrenci ogrenci)
        {
            context.Ogrencis.Update(ogrenci);
            await context.SaveChangesAsync();
            return ogrenci;
        }

        public async Task<bool> DeleteOgrenciAsync(int id)
        {
            var ogrenci = await context.Ogrencis.FirstOrDefaultAsync(a => a.Id == id);
            if (ogrenci == null)
                return false;

            context.Ogrencis.Remove(ogrenci);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
