using Application.DetailDto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IVeliService
    {
        Task<List<VeliDetailDto>> GetAllVeliAsync();
        Task<VeliDetailDto> GetVeliById(int id);
        Task<VeliDetailDto> UpdateVeli(CreationDto.UpdateAndCreateVeli veli,int VeliId);
        Task<VeliDetailDto> AddVeli(CreationDto.UpdateAndCreateVeli veli);
        Task<bool> DeleteVeli(int id);

    }
}
