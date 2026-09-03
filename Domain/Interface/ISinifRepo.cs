using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISinifRepo
    {
        Task<IEnumerable<Sinif>> GetAllSinif();
        Task<Sinif> GetSinifById(int id);
        Task<Sinif> GetSinifBySinifNo(string sinifNo);
        Task<Sinif> AddSinif(Sinif sinif);
        Task<Sinif> UpdateSinif(Sinif sinif);
        Task<bool> DeleteSinif(int id);
    }
}