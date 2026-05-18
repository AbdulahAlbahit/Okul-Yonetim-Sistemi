using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IDersRepo
    {

        Task<Ders> AddDersAsync(Ders ders);
        Task UpdateDersAsync(Ders ders);
        Task<bool> DeleteDersAsync(int id);
        Task<Ders> GetDersByIdAsync(int id);
        Task<List<Ders>> GetAllDersAsync();
        Task<Ders> GetDersByName(string name);

    }
}
