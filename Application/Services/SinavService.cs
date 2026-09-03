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
    public class SinavService(ISinavRepo repo, IMapper mapper) : ISinavService
    {
        public async Task<List<SinavDetailDto>> GetAllSinavAsync()
        {
            var sinavlar = await repo.GetAllSinavAsync();
            return mapper.Map<List<SinavDetailDto>>(sinavlar);
        }

        public async Task<SinavDetailDto> GetSinavByIdAsync(int id)
        {
            var sinav = await repo.GetSinavByIdAsync(id);
            if (sinav.Sinav_Id == 0)
                return null;

            return mapper.Map<SinavDetailDto>(sinav);
        }

        public async Task<List<SinavDetailDto>> GetSinavlarByDersIdAsync(int dersId)
        {
            var sinavlar = await repo.GetSinavlarByDersIdAsync(dersId);
            return mapper.Map<List<SinavDetailDto>>(sinavlar);
        }

        public async Task<List<SinavDetailDto>> GetSinavlarByHocaIdAsync(int hocaId)
        {
            var sinavlar = await repo.GetSinavlarByHocaIdAsync(hocaId);
            return mapper.Map<List<SinavDetailDto>>(sinavlar);
        }

        public async Task<SinavDetailDto> AddSinavAsync(CreateSinavDto createDto)
        {
            var sinav = mapper.Map<Sinav>(createDto);
            var result = await repo.AddSinavAsync(sinav);
            
            // Re-fetch to populate navigation properties (Ders, Hoca)
            var savedSinav = await repo.GetSinavByIdAsync(result.Sinav_Id);
            return mapper.Map<SinavDetailDto>(savedSinav);
        }

        public async Task<SinavDetailDto> UpdateSinavAsync(int id, UpdateSinavDto updateDto)
        {
            var existing = await repo.GetSinavByIdAsync(id);
            if (existing.Sinav_Id == 0)
                return null;

            mapper.Map(updateDto, existing);
            var result = await repo.UpdateSinavAsync(existing);
            
            // Re-fetch to populate navigation properties in case they changed
            var savedSinav = await repo.GetSinavByIdAsync(result.Sinav_Id);
            return mapper.Map<SinavDetailDto>(savedSinav);
        }

        public async Task<bool> DeleteSinavAsync(int id)
        {
            return await repo.DeleteSinavAsync(id);
        }
    }
}
