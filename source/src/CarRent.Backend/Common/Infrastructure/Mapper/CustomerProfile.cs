using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Model.CustomerManagement.Application;
using CarRent.Model.CustomerManagement.Domain;

namespace CarRent.Backend.Common.Infrastructure.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Zip, opt => opt.MapFrom(src => src.Zip.Zip))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Zip.Country))
                .ForMember(dest => dest.Place, opt => opt.MapFrom(src => src.Zip.Town));
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Zip, opt => opt.Ignore());

            CreateMap<ZipCode, ZipCodeDto>();
            CreateMap<ZipCodeDto, ZipCode>();
        }
    }
}
