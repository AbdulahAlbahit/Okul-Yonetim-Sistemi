using Application.Services;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repos
{
    public class SinifRepo(AppDbContext context) : ISinifRepo
    {
        public async Task<Sinif> GetSinifById(int id)
        {
        var sinif=await context.Sinifs.FirstOrDefaultAsync(a=>a.Sinif_Id==id);
            return sinif;
        }
    }
}
