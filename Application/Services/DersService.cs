using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
using System.Runtime.CompilerServices;
namespace Application.Services
{
    public class DersService(IDersRepo DersRepo,IMapper mapper,IPersonelRepo PerRepo ): IDersService
    {
        public async Task<DersDetailDto> AddDersAsync(CreateAndUpdateDersDto ders)
        {
            var Ders = mapper.Map<Ders>(ders);

          var AddedDers=  await DersRepo.AddDersAsync(Ders);
            var hocalar =  await PerRepo.GetHocaByDersId(AddedDers.Ders_Id);

            var Detail = mapper.Map<DersDetailDto>(Ders);
            if (hocalar != null)
            {
                for (int i = 0; i < hocalar.Count; i++)
                {

                    Detail.hocaBilgis[i].Hoca_no = hocalar[i].PerId;
                    Detail.hocaBilgis[i].Hoca_name = hocalar[i].Name;

                }
            }

            return Detail;



        }

        public async Task<bool> DeleteDersAsync(int id)
        {
            return await DersRepo.DeleteDersAsync(id);
        }

        public async Task<List<DersDetailDto>> GetAllDersAsync()
        {

            var list = new List<DersDetailDto>();

            var Dersler = await DersRepo.GetAllDersAsync();
            if (Dersler != null)
            {
                foreach (var item in Dersler)
                {
                    var DersDetail = mapper.Map<DersDetailDto>(item);
                    var personels = item.Personels.Where(a => a.DersId == DersDetail.Ders_Id).ToList();
                    if (personels != null)
                    {
                        for (int i=0;i<personels.Count;i++) {
                            DersDetail.hocaBilgis.Add(new HocaBilgi());
                            DersDetail.hocaBilgis[i].Hoca_no = personels[i].PerId;
                            DersDetail.hocaBilgis[i].Hoca_name = personels[i].Name;
                        
                        }

                    }
                    list.Add(DersDetail);
                }

            }


            return list;


        }

        public async Task<DersDetailDto> GetDersByIdAsync(int id)
        {

            var Ders = await DersRepo.GetDersByIdAsync(id);
            if (Ders != null)
            {
                var DersDetail = mapper.Map<DersDetailDto>(Ders);
                var personels=Ders.Personels.Where(a=>a.DersId==Ders.Ders_Id).ToList();
                if (personels != null)
                {
                    for (int i = 0; i < personels.Count; i++)
                    {

                        DersDetail.hocaBilgis[i].Hoca_no = personels[i].PerId;
                        DersDetail.hocaBilgis[i].Hoca_name = personels[i].Name;

                    }
                }
                return DersDetail;
            }


            return new DersDetailDto();
        }

        public async Task<DersDetailDto> GetDersByName(string name)
        {

            var ders = await DersRepo.GetDersByName(name);
            if (ders != null)
            {
                var Detail = mapper.Map<DersDetailDto>(ders);
                var personels = ders.Personels.Where(a => a.DersId == ders.Ders_Id).ToList();
                if (personels != null)
                {
                    for (int i = 0; i < personels.Count; i++)
                    {

                        Detail.hocaBilgis[i].Hoca_no = personels[i].PerId;
                        Detail.hocaBilgis[i].Hoca_name = personels[i].Name;

                    }
                }
                return Detail;
            }

            return new DersDetailDto(); ;

        }

        public async Task<DersDetailDto> UpdateDersAsync(CreateAndUpdateDersDto ders, int id)
        {

            var existingDers = await DersRepo.GetDersByIdAsync(id);
            if (existingDers != null)
            {
                mapper.Map(ders, existingDers);

                await DersRepo.UpdateDersAsync(existingDers);
                var Detail = mapper.Map<DersDetailDto>(existingDers);
                var personels = existingDers.Personels.Where(a => a.DersId == existingDers.Ders_Id).ToList();
                if (personels != null)
                {
                    for (int i = 0; i < personels.Count; i++)
                    {

                        Detail.hocaBilgis[i].Hoca_no = personels[i].PerId;
                        Detail.hocaBilgis[i].Hoca_name = personels[i].Name;

                    }
                }
                return Detail;
            }

            return new DersDetailDto(); ;
        }
    }
}
