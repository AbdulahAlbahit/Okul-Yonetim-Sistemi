using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OgrenciSinavService(IOgrenciSinavRepo repo, IMapper mapper) : IOgrenciSinavService
    {
        public async Task<List<OgrenciSinavDetailDto>> GetAllOgrenciSinavAsync()
        {
            var sinavlar = await repo.GetAllOgrenciSinavAsync();
            return mapper.Map<List<OgrenciSinavDetailDto>>(sinavlar);
        }

        public async Task<OgrenciSinavDetailDto> GetOgrenciSinavByIdAsync(int id)
        {
            var result = await repo.GetOgrenciSinavByIdAsync(id);
            if (result.Ogrenci_Sinav_Id == 0)
                return null;

            return mapper.Map<OgrenciSinavDetailDto>(result);
        }

        public async Task<List<OgrenciSinavDetailDto>> GetOgrenciSinavlarBySinavIdAsync(int sinavId)
        {
            var sinavlar = await repo.GetOgrenciSinavlarBySinavIdAsync(sinavId);
            return mapper.Map<List<OgrenciSinavDetailDto>>(sinavlar);
        }

        public async Task<List<OgrenciSinavDetailDto>> GetOgrenciSinavlarByOgrenciIdAsync(int ogrenciId)
        {
            var sinavlar = await repo.GetOgrenciSinavlarByOgrenciIdAsync(ogrenciId);
            return mapper.Map<List<OgrenciSinavDetailDto>>(sinavlar);
        }

        public async Task<OgrenciDersSonucDto> CalculatePassStatusAsync(int ogrenciId, int dersId)
        {
            var sinavlar = await repo.GetOgrenciSinavlarByOgrenciAndDersIdAsync(ogrenciId, dersId);

            if (sinavlar == null || sinavlar.Count == 0)
                return null; 

            var vize = sinavlar.FirstOrDefault(s => s.Sinav.SinavType == SinavType.Vize);
            var final = sinavlar.FirstOrDefault(s => s.Sinav.SinavType == SinavType.Final);

            
            var firstRecord = sinavlar.First();
            string ogrenciAd = firstRecord.Ogrenci != null ? $"{firstRecord.Ogrenci.Name} {firstRecord.Ogrenci.SecondName}" : "";
            string dersAd = firstRecord.Sinav.ders != null ? firstRecord.Sinav.ders.DersAdi : "";

            var sonuc = new OgrenciDersSonucDto
            {
                OgrenciAdSoyad = ogrenciAd,
                DersAdi = dersAd,
                VizeNotu = vize != null ? vize.Not : 0,
                FinalNotu = final != null ? final.Not : 0
            };

            if (vize == null || final == null)
            {
                sonuc.Durum = "Sınavlar Eksik (Vize veya Final girilmemiş)";
                return sonuc;
            }

            sonuc.Ortalama = (float)((vize.Not * 0.40) + (final.Not * 0.60));

            if (final.Not < 50)
            {
                sonuc.Durum = "Kaldı (Final notu 50'nin altında)";
            }
            else if (sonuc.Ortalama >= 50)
            {
                sonuc.Durum = "Geçti";
            }
            else
            {
                sonuc.Durum = "Kaldı (Ortalama 50'nin altında)";
            }

            return sonuc;
        }

        public async Task<OgrenciSinavDetailDto> AddOgrenciSinavAsync(CreateOgrenciSinavDto createDto)
        {
            var sinavNot = mapper.Map<OgrenciSinav>(createDto);
            var result = await repo.AddOgrenciSinavAsync(sinavNot);
            
            // Re-fetch to populate navigation properties
            var saved = await repo.GetOgrenciSinavByIdAsync(result.Ogrenci_Sinav_Id);
            return mapper.Map<OgrenciSinavDetailDto>(saved);
        }

        public async Task<OgrenciSinavDetailDto> UpdateOgrenciSinavAsync(int id, UpdateOgrenciSinavDto updateDto)
        {
            var existing = await repo.GetOgrenciSinavByIdAsync(id);
            if (existing.Ogrenci_Sinav_Id == 0)
                return null;

            mapper.Map(updateDto, existing);
            var result = await repo.UpdateOgrenciSinavAsync(existing);
            
            var saved = await repo.GetOgrenciSinavByIdAsync(result.Ogrenci_Sinav_Id);
            return mapper.Map<OgrenciSinavDetailDto>(saved);
        }

        public async Task<bool> DeleteOgrenciSinavAsync(int id)
        {
            return await repo.DeleteOgrenciSinavAsync(id);
        }
    }
}
