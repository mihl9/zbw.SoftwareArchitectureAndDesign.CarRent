using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;

namespace CarRent.Backend.Common.Infrastructure.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class.Type))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.Class.PricePerDay));

            CreateMap<CarDto, Car>().ForMember(dest => dest.Class, opt => opt.Ignore());

            CreateMap<CarClass, CarClassDto>();

            CreateMap<CarClassDto, CarClass>();
        }
    }
}
