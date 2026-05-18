using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreationDto.CreatedPersonelDto, DetailDto.PersonelDetailDto>().ReverseMap();
            CreateMap<CreationDto.CreatedPersonelDto, Personel>().ReverseMap();
            CreateMap<DetailDto.PersonelDetailDto, Personel>().ReverseMap();
            CreateMap<UpdatePersonelDto,Personel>().ReverseMap();
            CreateMap<Ders,CreateAndUpdateDersDto>().ReverseMap();
            CreateMap<Ders,DersDetailDto>().ReverseMap();
            
        }




    }
}
