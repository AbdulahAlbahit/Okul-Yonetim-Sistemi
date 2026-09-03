using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ISinavRepo
    {
        Task<List<Sinav>> GetAllSinavAsync();
        Task<Sinav> GetSinavByIdAsync(int id);
        Task<List<Sinav>> GetSinavlarByDersIdAsync(int dersId);
        Task<List<Sinav>> GetSinavlarByHocaIdAsync(int hocaId);
        Task<Sinav> AddSinavAsync(Sinav sinav);
        Task<Sinav> UpdateSinavAsync(Sinav sinav);
        Task<bool> DeleteSinavAsync(int id);
    }
}
