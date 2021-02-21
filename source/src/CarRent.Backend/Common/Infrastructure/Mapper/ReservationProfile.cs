using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Model.ReservationManagement.Application;
using CarRent.Model.ReservationManagement.Domain;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CarRent.Backend.Common.Infrastructure.Mapper
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car.Brand + ' ' + src.Car.Class.Type))
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.Firstname + ' ' + src.Customer.Lastname))
                .AfterMap((src, dest) => dest.TotalCost = src.TotalDays * src.Car.Class.PricePerDay);

            CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore());
        }
    }
}
