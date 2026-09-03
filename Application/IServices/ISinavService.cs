using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISinavService
    {
        Task<List<SinavDetailDto>> GetAllSinavAsync();
        Task<SinavDetailDto> GetSinavByIdAsync(int id);
        Task<List<SinavDetailDto>> GetSinavlarByDersIdAsync(int dersId);
        Task<List<SinavDetailDto>> GetSinavlarByHocaIdAsync(int hocaId);
        Task<SinavDetailDto> AddSinavAsync(CreateSinavDto createDto);
        Task<SinavDetailDto> UpdateSinavAsync(int id, UpdateSinavDto updateDto);
        Task<bool> DeleteSinavAsync(int id);
    }
}
