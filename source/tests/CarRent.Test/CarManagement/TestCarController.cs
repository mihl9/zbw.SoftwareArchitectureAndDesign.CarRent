﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CarManagement.API;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.Common.Infrastructure.Mapper;
using CarRent.Backend.Common.Interfaces;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarRent.Test.CarManagement
{
    public class TestCarController
    {
        private readonly IMapper _mapper;
        private readonly ICarService _service;

        private readonly Mock<IRepository<Car, Guid>> _repository;

        private readonly CarClass _basicClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 12,
            Type = CarClassType.Basic
        };
        private readonly CarClass _mediumClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 20,
            Type = CarClassType.Medium
        };
        private readonly CarClass _luxuryClass = new CarClass()
        {
            Id = Guid.NewGuid(),
            PricePerDay = 130,
            Type = CarClassType.Luxury
        };

        private readonly List<Car> _cars;
        public TestCarController()
        {
        
            var carClasses = new List<CarClass>()
            {
                _basicClass,
                _mediumClass,
                _luxuryClass
            };
            _cars = new List<Car>()
            {
                new Car()
                {
                    Id = Guid.NewGuid(),
                    Brand = "Toyota",
                    Class = _basicClass,
                    ClassId = _basicClass.Id,
                    Type = "PW"
                }
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CarProfile));
            }));

            _repository = new Mock<IRepository<Car, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_cars);
            _repository.Setup(x => x.Insert(It.IsAny<Car>()));

            _service = new CarService(_repository.Object);
        }

        [Fact]
        public void TestGetAll()
        {
            var controller = new CarController(_service, _mapper);
            
            var result = controller.Get();
            
            result.Should().NotBeEmpty().And.BeEquivalentTo(_cars, o=> o.ExcludingMissingMembers());
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new CarController(_service,_mapper);

            var carToAdd = new CarDto()
            {
                Id = Guid.NewGuid(),
                Brand = "Hyundai",
                ClassId = _luxuryClass.Id,
                Type = "PW"
            };

            controller.Post(carToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Car>()));
        }
    }
}
