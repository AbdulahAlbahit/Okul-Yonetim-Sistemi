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
    
            var Detail = mapper.Map<DersDetailDto>(AddedDers);
          
            return Detail;



        }

        public async Task<bool> DeleteDersAsync(int id)
        {
            return await DersRepo.DeleteDersAsync(id);
        }

        public async Task<List<DersDetailDto>> GetAllDersAsync()
        {

            var Dersler = await DersRepo.GetAllDersAsync();
            if (Dersler != null)
            {
                
                var mappedlist=mapper.Map<List<DersDetailDto>>(Dersler);

                return mappedlist;
            }


            return new List<DersDetailDto>();


        }

        public async Task<DersDetailDto> GetDersByIdAsync(int id)
        {

            var Ders = await DersRepo.GetDersByIdAsync(id);
            if (Ders != null)
            {
                var DersDetail = mapper.Map<DersDetailDto>(Ders);
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
               
                return Detail;
            }

            return new DersDetailDto(); ;
        }
    }
}
