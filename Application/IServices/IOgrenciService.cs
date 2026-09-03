using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IOgrenciService
    {
        Task<List<OgrenciDetailDto>> GetAllOgrenciAsync();
        Task<OgrenciDetailDto> GetOgrenciByIdAsync(int id);
        Task<OgrenciDetailDto> GetOgrenciByNoAsync(string ogrenciNo);
        Task<List<OgrenciDetailDto>> GetOgrencilerBySinifIdAsync(int sinifId);
        Task<OgrenciDetailDto> AddOgrenciAsync(CreateOgrenciDto createDto);
        Task<OgrenciDetailDto> UpdateOgrenciAsync(int id, UpdateOgrenciDto updateDto);
        Task<bool> DeleteOgrenciAsync(int id);
    }
}
