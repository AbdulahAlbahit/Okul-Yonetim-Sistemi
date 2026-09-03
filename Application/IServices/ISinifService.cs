using Application.CreationDto;
using Application.DetailDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISinifService
    {
        Task<IEnumerable<SinifDetailDto>> GetAllSinifsAsync();
        Task<SinifDetailDto> GetSinifByIdAsync(int id);
        Task<SinifDetailDto> GetSinifBySinifNoAsync(string sinifNo);
        Task<SinifDetailDto> AddSinifAsync(CreateAndUpdateSinifDto createDto);
        Task<SinifDetailDto> UpdateSinifAsync(int id, CreateAndUpdateSinifDto updateDto);
        Task<bool> DeleteSinifAsync(int id);
    }
}
