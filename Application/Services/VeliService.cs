using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class VeliService (IMapper mapper,IVeliRepo repo): IVeliService
    {
        public async Task<VeliDetailDto> AddVeli(UpdateAndCreateVeli veli)
        {
            var Veli = mapper.Map<Veli>(veli);

            var AddedVeli=await repo.AddVeli(Veli);

         var Detail=   mapper.Map<VeliDetailDto>(AddedVeli);


            return Detail;


        }

        public async Task<bool> DeleteVeli(int id)
        {
               return await repo.DeleteVeli(id);
        }

        public async Task<List<VeliDetailDto>> GetAllVeliAsync()
        {
            var list=await repo.GetAllVeliAsync();

            var newList=new List<VeliDetailDto>();


            foreach (var item in list)
            {
            var Detail=mapper.Map<VeliDetailDto>(list);
             newList.Add(Detail);
            }


            return newList ;


        }

        public async Task<VeliDetailDto> GetVeliById(int id)
        {
            var Veli=await repo.GetVeliById(id);
            if (Veli != null)
            {
               var Detail= mapper.Map<VeliDetailDto>(Veli);
                return Detail ;
            }

            return null;

        }


        public async Task<VeliDetailDto> UpdateVeli(UpdateAndCreateVeli veli,int VeliId)
        {       
            var existingVeli=await repo.GetVeliById(VeliId);

            if (existingVeli != null)
            {
                mapper.Map(veli, existingVeli);
                await repo.UpdateVeli(existingVeli);

                return mapper.Map<VeliDetailDto>(existingVeli) ;
            }
            return null;

        }


    }
}
