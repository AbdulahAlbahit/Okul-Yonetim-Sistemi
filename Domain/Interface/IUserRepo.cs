using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepo
    {
        Task<User> GetByGirisNoAsync(string girisNo);
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<bool> GirisNoExistsAsync(string girisNo);
    }
}
