using Domain.Entity;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class UserRepo(AppDbContext context) : IUserRepo
    {
        public async Task<User> GetByGirisNoAsync(string girisNo)
        {
            return await context.Users
                .Include(u => u.Ogrenci)
                .Include(u => u.Personel)
                .FirstOrDefaultAsync(u => u.GirisNo == girisNo);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Ogrenci)
                .Include(u => u.Personel)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> GirisNoExistsAsync(string girisNo)
        {
            return await context.Users.AnyAsync(u => u.GirisNo == girisNo);
        }

        public async Task UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
