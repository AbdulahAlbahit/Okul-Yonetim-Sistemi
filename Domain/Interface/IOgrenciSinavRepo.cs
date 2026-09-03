using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IOgrenciSinavRepo
    {
        Task<List<OgrenciSinav>> GetAllOgrenciSinavAsync();
        Task<OgrenciSinav> GetOgrenciSinavByIdAsync(int id);
        Task<List<OgrenciSinav>> GetOgrenciSinavlarBySinavIdAsync(int sinavId);
        Task<List<OgrenciSinav>> GetOgrenciSinavlarByOgrenciIdAsync(int ogrenciId);
        Task<List<OgrenciSinav>> GetOgrenciSinavlarByOgrenciAndDersIdAsync(int ogrenciId, int dersId);
        Task<OgrenciSinav> AddOgrenciSinavAsync(OgrenciSinav ogrenciSinav);
        Task<OgrenciSinav> UpdateOgrenciSinavAsync(OgrenciSinav ogrenciSinav);
        Task<bool> DeleteOgrenciSinavAsync(int id);
    }
}
