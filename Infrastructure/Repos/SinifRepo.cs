using Application.Services;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class SinifRepo(AppDbContext context) : ISinifRepo
    {
        public async Task<IEnumerable<Sinif>> GetAllSinif()
        {
            return await context.Sinifs.ToListAsync();
        }

        public async Task<Sinif> GetSinifById(int id)
        {
            var sinif = await context.Sinifs.FirstOrDefaultAsync(a => a.Sinif_Id == id);
            if (sinif != null)
                return sinif;

            return new Sinif();
        }

        public async Task<Sinif> GetSinifBySinifNo(string sinifNo)
        {
            var sinif = await context.Sinifs.FirstOrDefaultAsync(a => a.SinifNo == sinifNo);
            if (sinif != null)
                return sinif;

            return new Sinif();
        }

        public async Task<Sinif> AddSinif(Sinif sinif)
        {
            await context.Sinifs.AddAsync(sinif);
            await context.SaveChangesAsync();
            return sinif;
        }

        public async Task<Sinif> UpdateSinif(Sinif sinif)
        {
            context.Sinifs.Update(sinif);
            await context.SaveChangesAsync();
            return sinif;
        }

        public async Task<bool> DeleteSinif(int id)
        {
            var sinif = await context.Sinifs.FirstOrDefaultAsync(a => a.Sinif_Id == id);
            if (sinif == null)
                return false;

            context.Sinifs.Remove(sinif);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
