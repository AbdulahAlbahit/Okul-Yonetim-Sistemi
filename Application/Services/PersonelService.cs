using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
namespace Application.Services
{
    internal class PersonelService(IPersonelRepo repo,IMapper mapper) : IPersonelService
    {
        public async Task<PersonelDetailDto> AddPersonelAsync(CreatedPersonelDto createdPersonel)
        {
            var personel = mapper.Map<Personel>(createdPersonel);

            var yeniPer = await repo.AddPersonel(personel);

            var detailDto = mapper.Map<PersonelDetailDto>(yeniPer);


            return detailDto;


        }

        public async Task<bool> DeletePersonelByIdAsync(int Id)
        {
            return await repo.DeletePersonelById(Id);
        }

        public async Task<List<PersonelDetailDto>> GetAllPersonelsAsync()
        {
            var personels = new List<PersonelDetailDto>();

            var list = await repo.GetAllPersonelsAsync();

            foreach (var item in list)
            {
                var per = mapper.Map<PersonelDetailDto>(item);
                personels.Add(per);

            }

            return personels;



        }

        public async Task<PersonelDetailDto> GetPersonelByIdAsync(int id)
        {
            var personel = await repo.GetPersonelByIdAsync(id);
            if (personel != null)
            {
                var PerDetail = mapper.Map<PersonelDetailDto>(personel);
                return PerDetail;
            }
            return null;


        }

        public async Task<PersonelDetailDto> UpdatePersonelAsync(UpdatePersonelDto personel, int PersonelId)
        {
            var existingPersonel = await repo.GetPersonelByIdAsync(PersonelId);
            if (existingPersonel != null)
            {
                mapper.Map(personel, existingPersonel);

                await repo.UpdatePersonel(existingPersonel);

                return mapper.Map<PersonelDetailDto>(existingPersonel);
            }

            return null;
        }
    }
}
