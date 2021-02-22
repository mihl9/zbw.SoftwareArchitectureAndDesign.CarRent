using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CarManagement.API;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.Common.Infrastructure.Mapper;
using CarRent.Backend.Common.Interfaces;
using CarRent.Backend.CustomerManagement.API;
using CarRent.Backend.CustomerManagement.Application;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Application;
using CarRent.Model.CustomerManagement.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarRent.Test.CustomerManagement
{
    public class TestCustomerController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _service;

        private readonly Mock<IRepository<Customer, Guid>> _repository;

        private readonly ZipCode _zip1 = new ZipCode()
        {
            Id = Guid.NewGuid(),
            Country = "Switzerland",
            Town = "Hansel",
            Zip = "90123"
        };
        

        private readonly List<Customer> _entities;
        public TestCustomerController()
        {
        
            
            _entities = new List<Customer>()
            {
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "asd",
                    Lastname = "asdf",
                    Street = "asdf",
                    Zip = _zip1,
                    ZipId = _zip1.Id
                }   
            };
            _mapper = new Mapper(new MapperConfiguration(conf =>
            {
                conf.AddProfile(typeof(CustomerProfile));
            }));

            _repository = new Mock<IRepository<Customer, Guid>>();

            _repository.Setup(x => x.GetAll()).Returns(_entities);
            _repository.Setup(x => x.Insert(It.IsAny<Customer>()));

            _service = new CustomerService(_repository.Object);
        }

        [Fact]
        public void TestGetAll()
        {
            var controller = new CustomerController(_service, _mapper);
            
            var result = controller.Get();
            
            result.Should().NotBeEmpty().And.BeEquivalentTo(_entities, o=> o.ExcludingMissingMembers());
        }

        [Fact]
        public void TestAdd()
        {
            var controller = new CustomerController(_service,_mapper);

            var entityToAdd = new CustomerDto()
            {
                Id = Guid.NewGuid()
            };

            controller.Post(entityToAdd);

            _repository.Verify(x => x.Insert(It.IsAny<Customer>()));
        }
    }
}
