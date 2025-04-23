using AutoMapper;
using WebAPI_NationalPark_1035.Models;
using WebAPI_NationalPark_1035.Models.DTOs;

namespace WebAPI_NationalPark_1035.DtoMaping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<NationalParkDto,NationalPark>().ReverseMap();
            CreateMap<Trail,TrailDto>().ReverseMap();
        }
    }
}
//database--model--rep--dto-client
//client--dto-rep--model--database  