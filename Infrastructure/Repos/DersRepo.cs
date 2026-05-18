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
            context.Dersler.Add(ders);
            await context.SaveChangesAsync();
            return ders;
        }

        public async Task<bool> DeleteDersAsync(int id)
        {
           var ders=await GetDersByIdAsync(id);
            if (ders != null)
            {
                context.Dersler.Remove(ders);
                await context.SaveChangesAsync();
                return true;
            }


            return false; ;
        }

        public async Task<List<Ders>> GetAllDersAsync()
        {
            var list = await context.Dersler.Include(a=>a.personel).AsNoTracking().ToListAsync();

           return list;
        }

        public async Task<Ders> GetDersByIdAsync(int id)
        {
            var Ders = await context.Dersler.Include(a => a.personel).AsNoTracking().FirstOrDefaultAsync(a=>a.Ders_Id==id);
            return Ders;
        }

        public async Task<Ders> GetDersByName(string name)
        {
            var ders = await context.Dersler.Include(a => a.personel).AsNoTracking().FirstOrDefaultAsync(a => a.DersAdi == name);
            return ders;
        }

        public async Task UpdateDersAsync(Ders ders)
        {
           context.Dersler.Update(ders);
            await context.SaveChangesAsync();
        }
    }
}
