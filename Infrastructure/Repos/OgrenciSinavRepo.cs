using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class OgrenciSinavRepo(AppDbContext context) : IOgrenciSinavRepo
    {
        public async Task<List<OgrenciSinav>> GetAllOgrenciSinavAsync()
        {
            return await context.OgrenciSinavs
                .Include(a => a.Ogrenci)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.ders)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.personel)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OgrenciSinav> GetOgrenciSinavByIdAsync(int id)
        {
            var result = await context.OgrenciSinavs
                .Include(a => a.Ogrenci)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.ders)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.personel)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Ogrenci_Sinav_Id == id);
                
            return result ?? new OgrenciSinav();
        }

        public async Task<List<OgrenciSinav>> GetOgrenciSinavlarByOgrenciIdAsync(int ogrenciId)
        {
            return await context.OgrenciSinavs
                .Include(a => a.Ogrenci)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.ders)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.personel)
                .Where(a => a.Ogrenci_id == ogrenciId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<OgrenciSinav>> GetOgrenciSinavlarBySinavIdAsync(int sinavId)
        {
            return await context.OgrenciSinavs
                .Include(a => a.Ogrenci)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.ders)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.personel)
                .Where(a => a.Sinav_id == sinavId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<OgrenciSinav>> GetOgrenciSinavlarByOgrenciAndDersIdAsync(int ogrenciId, int dersId)
        {
            return await context.OgrenciSinavs
                .Include(a => a.Ogrenci)
                .Include(a => a.Sinav)
                    .ThenInclude(s => s.ders)
                .Where(a => a.Ogrenci_id == ogrenciId && a.Sinav.Ders_Id == dersId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OgrenciSinav> AddOgrenciSinavAsync(OgrenciSinav ogrenciSinav)
        {
            await context.OgrenciSinavs.AddAsync(ogrenciSinav);
            await context.SaveChangesAsync();
            return ogrenciSinav;
        }

        public async Task<OgrenciSinav> UpdateOgrenciSinavAsync(OgrenciSinav ogrenciSinav)
        {
            context.OgrenciSinavs.Update(ogrenciSinav);
            await context.SaveChangesAsync();
            return ogrenciSinav;
        }

        public async Task<bool> DeleteOgrenciSinavAsync(int id)
        {
            var record = await context.OgrenciSinavs.FirstOrDefaultAsync(a => a.Ogrenci_Sinav_Id == id);
            if (record == null)
                return false;

            context.OgrenciSinavs.Remove(record);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
