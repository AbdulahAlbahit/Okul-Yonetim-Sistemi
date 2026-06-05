using Domain.Entity;

namespace Application.Services
{
    public interface ISinifRepo
    {
        Task<Sinif> GetSinifById(int  id);
    }
}