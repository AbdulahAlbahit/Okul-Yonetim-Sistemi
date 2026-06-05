using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repos
{
    internal class DersRepo (AppDbContext context): IDersRepo
    {
        public async Task<Ders> AddDersAsync(Ders ders)
        {
            context.Derss.Add(ders);
            await context.SaveChangesAsync();
            return ders;
        }

        public async Task<bool> DeleteDersAsync(int id)
        {
            var ders = await GetDersByIdAsync(id);
            if (ders != null)
            {
                context.Derss.Remove(ders);
                await context.SaveChangesAsync();
                return true;
            }


            return false; ;
        }

        public async Task<List<Ders>> GetAllDersAsync()
        {
            var list = await context.Derss.Include(a => a.Personels).AsNoTracking().ToListAsync();

            return list;
        }

        public async Task<Ders> GetDersByIdAsync(int id)
        {
            var Ders = await context.Derss.Include(a => a.Personels).AsNoTracking().FirstOrDefaultAsync(a => a.Ders_Id == id);
            return Ders;
        }

        public async Task<Ders> GetDersByName(string name)
        {
            var ders = await context.Derss.Include(a => a.Personels).AsNoTracking().FirstOrDefaultAsync(a => a.DersAdi == name);
            return ders;
        }

        public async Task<List<Ders>> GetDerslerByIdsAsync(List<int> id)
        {
            var dersler = await context.Derss.Where(a => id.Contains(a.Ders_Id)).AsNoTracking().ToListAsync() ;
            return dersler; 
        }

        public async Task UpdateDersAsync(Ders ders)
        {
            context.Derss.Update(ders);
            await context.SaveChangesAsync();
        }
    }
}
