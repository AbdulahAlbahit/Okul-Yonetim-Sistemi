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
           context.Velis.Add(veli);
            await context.SaveChangesAsync();
            return veli;
        }

        public async Task<bool> DeleteVeli(int id)
        {
            var veli=await GetVeliById(id);
            if (veli != null) { 
              context.Velis.Remove(veli);
                await context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<Veli>> GetAllVeliAsync()
        {
            return await context.Velis.AsNoTracking().ToListAsync();

        }

        public async Task<Veli> GetVeliById(int id)
        {
            return await context.Velis.AsNoTracking().FirstOrDefaultAsync(a=>a.Veli_Id==id);
        }

      
        public async Task<Veli> UpdateVeli(Veli veli)
        {
           context.Velis.Update(veli);
            await context.SaveChangesAsync();
            return veli;
        }
    }
}
