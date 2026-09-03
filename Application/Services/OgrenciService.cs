using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OgrenciService(IOgrenciRepo repo, IAuthService authService, IMapper mapper) : IOgrenciService
    {
        public async Task<List<OgrenciDetailDto>> GetAllOgrenciAsync()
        {
            var ogrenciler = await repo.GetAllOgrenciAsync();
            return mapper.Map<List<OgrenciDetailDto>>(ogrenciler);
        }

        public async Task<OgrenciDetailDto> GetOgrenciByIdAsync(int id)
        {
            var ogrenci = await repo.GetOgrenciByIdAsync(id);
            if (ogrenci.Id == 0)
                return null;

            return mapper.Map<OgrenciDetailDto>(ogrenci);
        }

        public async Task<OgrenciDetailDto> GetOgrenciByNoAsync(string ogrenciNo)
        {
            var ogrenci = await repo.GetOgrenciByNoAsync(ogrenciNo);
            if (ogrenci.Id == 0)
                return null;

            return mapper.Map<OgrenciDetailDto>(ogrenci);
        }

        public async Task<List<OgrenciDetailDto>> GetOgrencilerBySinifIdAsync(int sinifId)
        {
            var ogrenciler = await repo.GetOgrencilerBySinifIdAsync(sinifId);
            return mapper.Map<List<OgrenciDetailDto>>(ogrenciler);
        }

        public async Task<OgrenciDetailDto> AddOgrenciAsync(CreateOgrenciDto createDto)
        {
            var ogrenci = mapper.Map<Ogrenci>(createDto);
            var result = await repo.AddOgrenciAsync(ogrenci);
            
            // Otomatik olarak bu öğrenci için User hesabı oluştur
            await authService.CreateUserForOgrenciAsync(result);
            
            // Re-fetch to populate navigation properties (Sinif, Veli)
            var savedOgrenci = await repo.GetOgrenciByIdAsync(result.Id);
            return mapper.Map<OgrenciDetailDto>(savedOgrenci);
        }

        public async Task<OgrenciDetailDto> UpdateOgrenciAsync(int id, UpdateOgrenciDto updateDto)
        {
            var existing = await repo.GetOgrenciByIdAsync(id);
            if (existing.Id == 0)
                return null;

            mapper.Map(updateDto, existing);
            var result = await repo.UpdateOgrenciAsync(existing);
            
            // Re-fetch to populate navigation properties (Sinif, Veli) in case they changed
            var savedOgrenci = await repo.GetOgrenciByIdAsync(result.Id);
            return mapper.Map<OgrenciDetailDto>(savedOgrenci);
        }

        public async Task<bool> DeleteOgrenciAsync(int id)
        {
            return await repo.DeleteOgrenciAsync(id);
        }
    }
}
