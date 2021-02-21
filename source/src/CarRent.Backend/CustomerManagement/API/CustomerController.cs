using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CarManagement.Application;
using CarRent.Backend.CustomerManagement.Application;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Application;
using CarRent.Model.CustomerManagement.Domain;

namespace CarRent.Backend.CustomerManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CustomerDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<CustomerDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public List<CustomerDto> Get(Guid id)
        {
            return _service.GetById(id).Select(entity => _mapper.Map<CustomerDto>(entity)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] CustomerDto entity)
        {
            var c = _mapper.Map<Customer>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerDto entity)
        {
            var c = _mapper.Map<Customer>(entity);
            c.Id = id;
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
