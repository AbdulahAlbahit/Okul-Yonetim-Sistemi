using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IOgrenciRepo
    {
        Task<List<Ogrenci>> GetAllOgrenciAsync();
        Task<Ogrenci> GetOgrenciByIdAsync(int id);
        Task<Ogrenci> GetOgrenciByNoAsync(string ogrenciNo);
        Task<List<Ogrenci>> GetOgrencilerBySinifIdAsync(int sinifId);
        Task<Ogrenci> AddOgrenciAsync(Ogrenci ogrenci);
        Task<Ogrenci> UpdateOgrenciAsync(Ogrenci ogrenci);
        Task<bool> DeleteOgrenciAsync(int id);
    }
}
