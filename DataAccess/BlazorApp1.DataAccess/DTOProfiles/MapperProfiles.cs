using AutoMapper;
using EF = BlazorApp1.Data.Models;
using DTO = BlazorApp1.DTOs.DTOs;
using BlazorApp1.Data.Models;

namespace BlazorApp1.DataAccess.DTOProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            //Cars
            CreateMap<EF.Car, DTO.CarDetails>().ReverseMap();
            
            //Owners
            CreateMap<EF.Owner, DTO.OwnerDetail>().ReverseMap();
        }
    }
}
