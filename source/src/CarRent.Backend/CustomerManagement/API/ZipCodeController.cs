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
    public class ZipCodeController : ControllerBase
    {
        private readonly IZipCodeService _service;
        private readonly IMapper _mapper;

        public ZipCodeController(IZipCodeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ZipCodeDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<ZipCodeDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public List<ZipCodeDto> Get(Guid id)
        {
            return _service.GetById(id).Select(entity => _mapper.Map<ZipCodeDto>(entity)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] ZipCodeDto entity)
        {
            var c = _mapper.Map<ZipCode>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ZipCodeDto entity)
        {
            var c = _mapper.Map<ZipCode>(entity);
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
