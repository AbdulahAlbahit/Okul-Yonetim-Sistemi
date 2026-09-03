using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IPersonelRepo
    {
        Task<List<Personel>> GetAllPersonelsAsync();
        Task<Personel> GetPersonelByIdAsync(int id);
        Task<Personel> AddPersonel(Personel personel);
        Task UpdatePersonel(Personel personel);
        Task<bool> DeletePersonelById(int Id);
        Task<List<Personel>> GetHocaByDersId(int dersId);
        Task<List<Personel>> GetHocalarByDersIdAsync(List<int> dersId);
       
    }
}
