using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entity;
namespace Application.Services
{
    public class DersService(IDersRepo DersRepo,IMapper mapper,IPersonelService PerService ) : IDersService
    {
        public async Task<DersDetailDto> AddDersAsync(CreateAndUpdateDersDto ders)
        {
            var Ders = mapper.Map<Ders>(ders);
             
                 await DersRepo.AddDersAsync(Ders);
            var hocaAdi =  PerService.GetPersonelByIdAsync(Ders.Hoca_No).Result.Name;

            var Detail=mapper.Map<DersDetailDto>(Ders);
            Detail.HocaAdi = hocaAdi;

            return Detail;



        }

        public async Task<bool> DeleteDersAsync(int id)
        {
            return await DersRepo.DeleteDersAsync(id);
        }

        public async Task<List<DersDetailDto>> GetAllDersAsync()
        {

            var list = new List<DersDetailDto>();

            var Dersler=await DersRepo.GetAllDersAsync();
            if(Dersler != null)
            {
                foreach (var item in Dersler)
                {
                    var DersDetail = mapper.Map<DersDetailDto>(item);
                    DersDetail.HocaAdi = item.personel.Name;
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
                DersDetail.HocaAdi = Ders.personel.Name;
                return DersDetail;


            }
            return null;
        }

        public async Task<DersDetailDto> GetDersByName(string name)
        {

            var ders = await DersRepo.GetDersByName(name);
            if (ders != null)
            {
                var Detail = mapper.Map<DersDetailDto>(ders);
                Detail.HocaAdi = ders.personel.Name;

                return Detail;
            }

            return null;

        }

        public async Task<DersDetailDto> UpdateDersAsync(CreateAndUpdateDersDto ders,int id)
        {

            var existingDers = await DersRepo.GetDersByIdAsync(id);
            if(existingDers != null)
            {
                mapper.Map(ders, existingDers);

                await DersRepo.UpdateDersAsync(existingDers);
                    var Detail=mapper.Map<DersDetailDto>(existingDers);
                Detail.HocaAdi = existingDers.personel.Name;

                return Detail;
            }

            return null;
        }
    }
}
