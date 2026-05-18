using Application.CreationDto;
using Application.DetailDto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IDersService
    {
        Task<DersDetailDto> AddDersAsync(CreateAndUpdateDersDto ders);
        Task<DersDetailDto> UpdateDersAsync(CreateAndUpdateDersDto ders,int id);
        Task<bool> DeleteDersAsync(int id);
        Task<DersDetailDto> GetDersByIdAsync(int id);
        Task<List<DersDetailDto>> GetAllDersAsync();
        Task<DersDetailDto> GetDersByName(string name);


    }
}
