using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using AutoMapper;
using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SinifService(ISinifRepo repo, IMapper mapper) : ISinifService
    {
        public async Task<IEnumerable<SinifDetailDto>> GetAllSinifsAsync()
        {
            var sinifs = await repo.GetAllSinif();
            return mapper.Map<IEnumerable<SinifDetailDto>>(sinifs);
        }

        public async Task<SinifDetailDto> GetSinifByIdAsync(int id)
        {
            var sinif = await repo.GetSinifById(id);
            if (sinif.Sinif_Id == 0)
                return null;
                
            return mapper.Map<SinifDetailDto>(sinif);
        }

        public async Task<SinifDetailDto> GetSinifBySinifNoAsync(string sinifNo)
        {
            var sinif = await repo.GetSinifBySinifNo(sinifNo);
            if (sinif.Sinif_Id == 0)
                return null;
                
            return mapper.Map<SinifDetailDto>(sinif);
        }

        public async Task<SinifDetailDto> AddSinifAsync(CreateAndUpdateSinifDto createDto)
        {
            var sinif = mapper.Map<Sinif>(createDto);
            var result = await repo.AddSinif(sinif);
            return mapper.Map<SinifDetailDto>(result);
        }

        public async Task<SinifDetailDto> UpdateSinifAsync(int id, CreateAndUpdateSinifDto updateDto)
        {
            var existingSinif = await repo.GetSinifById(id);
            if (existingSinif.Sinif_Id == 0)
                return null;

            mapper.Map(updateDto, existingSinif);
            var result = await repo.UpdateSinif(existingSinif);
            return mapper.Map<SinifDetailDto>(result);
        }

        public async Task<bool> DeleteSinifAsync(int id)
        {
            return await repo.DeleteSinif(id);
        }
    }
}
