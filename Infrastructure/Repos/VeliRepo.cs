using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repos
{
    public class VeliRepo (AppDbContext context): IVeliRepo
    {
        public async Task<Veli> AddVeli(Veli veli)
        {
           context.Veliler.Add(veli);
            await context.SaveChangesAsync();
            return veli;
        }

        public async Task<bool> DeleteVeli(int id)
        {
            var veli=await GetVeliById(id);
            if (veli != null) { 
              context.Veliler.Remove(veli);
                await context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<Veli>> GetAllVeliAsync()
        {
            return await context.Veliler.AsNoTracking().ToListAsync();

        }

        public async Task<Veli> GetVeliById(int id)
        {
            return await context.Veliler.AsNoTracking().FirstOrDefaultAsync(a=>a.Veli_Id==id);
        }

      
        public async Task<Veli> UpdateVeli(Veli veli)
        {
           context.Veliler.Update(veli);
            await context.SaveChangesAsync();
            return veli;
        }
    }
}
