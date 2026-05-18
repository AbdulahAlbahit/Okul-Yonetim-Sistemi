using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IVeliRepo
    {
        Task<List<Veli>> GetAllVeliAsync();
        Task<Veli> GetVeliById(int id)  ;
        Task<Veli> UpdateVeli(Veli veli);
        Task<Veli> AddVeli(Veli veli);
        Task<bool> DeleteVeli(int id);
    }
}
