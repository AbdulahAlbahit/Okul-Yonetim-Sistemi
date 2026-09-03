using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repos
{
    internal class PersoneRepo(AppDbContext context) : IPersonelRepo
    {


        public async Task<Personel> AddPersonel(Personel personel)
        {
            context.Add(personel);
            await context.SaveChangesAsync();
            return personel;
        }


        public async Task<List<Personel>> GetAllPersonelsAsync()
        {
            var list = await context.Personels.ToListAsync();
            return list;
        }

        public async Task<Personel> GetPersonelByIdAsync(int id)
        {
            var personel = await context.Personels.FirstOrDefaultAsync(a => a.PerId == id);
            if(personel!=null)
            return personel;

            return new Personel();

        }


        public async Task UpdatePersonel(Personel personel)
        {
            context.Update(personel);
            await context.SaveChangesAsync();

        }



        public async Task<bool> DeletePersonelById(int Id)
        {

            var personel =await  GetPersonelByIdAsync(Id);

            if (personel != null)
            {
                context.Personels.Remove(personel);

                await context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<List<Personel>> GetHocaByDersId(int dersId)
        {
            var hocalar= await context.Personels.Where(a=>a.DersId==dersId).AsNoTracking().ToListAsync();  
            return hocalar;
        }

        public async Task<List<Personel>> GetHocalarByDersIdAsync(List<int> dersId)
        {
            var hocalar = await context.Personels.Where(a=>dersId.Contains(a.DersId)).AsNoTracking().ToListAsync();
            return hocalar;
        }
    }
}
