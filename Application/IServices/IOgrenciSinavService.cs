using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IOgrenciSinavService
    {
        Task<List<OgrenciSinavDetailDto>> GetAllOgrenciSinavAsync();
        Task<OgrenciSinavDetailDto> GetOgrenciSinavByIdAsync(int id);
        Task<List<OgrenciSinavDetailDto>> GetOgrenciSinavlarBySinavIdAsync(int sinavId);
        Task<List<OgrenciSinavDetailDto>> GetOgrenciSinavlarByOgrenciIdAsync(int ogrenciId);
        Task<OgrenciDersSonucDto> CalculatePassStatusAsync(int ogrenciId, int dersId);
        Task<OgrenciSinavDetailDto> AddOgrenciSinavAsync(CreateOgrenciSinavDto createDto);
        Task<OgrenciSinavDetailDto> UpdateOgrenciSinavAsync(int id, UpdateOgrenciSinavDto updateDto);
        Task<bool> DeleteOgrenciSinavAsync(int id);
    }
}
