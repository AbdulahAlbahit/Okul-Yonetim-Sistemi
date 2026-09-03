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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreationDto.CreatedPersonelDto, DetailDto.PersonelDetailDto>().ReverseMap();
            CreateMap<CreationDto.CreatedPersonelDto, Personel>().ReverseMap();
            CreateMap<DetailDto.PersonelDetailDto, Personel>().ReverseMap();
            CreateMap<UpdatePersonelDto, Personel>().ReverseMap();
            CreateMap<Ders, CreateAndUpdateDersDto>().ReverseMap();

            CreateMap<Ders, DersDetailDto>()
             .ForMember(dest => dest.hocaBilgis, opt => opt.MapFrom(src => src.Personels))
                .ReverseMap();

            CreateMap<Personel, HocaBilgi>().
                ForMember(dest => dest.Hoca_no, opt => opt.MapFrom(src => src.PerId))
                .ForMember(dest => dest.Hoca_name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Program, DetailDto.ProgramDetailDto>().ReverseMap();
            CreateMap<Program, CreationDto.ProgramDto>().ReverseMap();

            CreateMap<Sinif, CreationDto.CreateAndUpdateSinifDto>().ReverseMap();
            CreateMap<Sinif, DetailDto.SinifDetailDto>().ReverseMap();

            CreateMap<Veli, CreationDto.UpdateAndCreateVeli>().ReverseMap();
            CreateMap<Veli, DetailDto.VeliDetailDto>().ReverseMap();


            CreateMap<Ogrenci, CreationDto.CreateOgrenciDto>().ReverseMap();
            CreateMap<Ogrenci, UpdateDto.UpdateOgrenciDto>().ReverseMap();
            CreateMap<Ogrenci, DetailDto.OgrenciDetailDto>()
                .ForMember(dest => dest.SinifNo, opt => opt.MapFrom(src => src.sinif != null ? src.sinif.SinifNo : string.Empty))
                .ForMember(dest => dest.VeliAd, opt => opt.MapFrom(src => src.veli != null ? src.veli.Name : string.Empty))
                .ForMember(dest => dest.VeliSoyad, opt => opt.MapFrom(src => src.veli != null ? src.veli.SecondName : string.Empty))
                .ReverseMap();

            CreateMap<Sinav, CreationDto.CreateSinavDto>().ReverseMap();
            CreateMap<Sinav, UpdateDto.UpdateSinavDto>().ReverseMap();
            CreateMap<Sinav, DetailDto.SinavDetailDto>()
                .ForMember(dest => dest.DersAdi, opt => opt.MapFrom(src => src.ders != null ? src.ders.DersAdi : string.Empty))
                .ForMember(dest => dest.HocaAdi, opt => opt.MapFrom(src => src.personel != null ? src.personel.Name : string.Empty))
                .ReverseMap();

            CreateMap<OgrenciSinav, CreationDto.CreateOgrenciSinavDto>().ReverseMap();
            CreateMap<OgrenciSinav, UpdateDto.UpdateOgrenciSinavDto>().ReverseMap();
            CreateMap<OgrenciSinav, DetailDto.OgrenciSinavDetailDto>()
                .ForMember(dest => dest.OgrenciAdSoyad, opt => opt.MapFrom(src => src.Ogrenci != null ? $"{src.Ogrenci.Name} {src.Ogrenci.SecondName}" : string.Empty))
                .ForMember(dest => dest.DersAdi, opt => opt.MapFrom(src => src.Sinav != null && src.Sinav.ders != null ? src.Sinav.ders.DersAdi : string.Empty))
                .ForMember(dest => dest.HocaAdi, opt => opt.MapFrom(src => src.Sinav != null && src.Sinav.personel != null ? src.Sinav.personel.Name : string.Empty))
                .ForMember(dest => dest.SinavType, opt => opt.MapFrom(src => src.Sinav != null ? src.Sinav.SinavType.ToString() : string.Empty))
                .ReverseMap();
        }
    }
}