using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CarManagement.Application;
using CarRent.Model.CarManagement.Application;
using CarRent.Model.CarManagement.Domain;

namespace CarRent.Backend.CarManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _service;
        private readonly IMapper _mapper;

        public CarClassController(ICarClassService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarClassDto> Get()
        {
            return _service.GetAll().Select(car => _mapper.Map<CarClassDto>(car)).ToList();
        }

        [HttpGet("{id}")]
        public List<CarClassDto> Get(Guid id)
        {
            return _service.GetById(id).Select(car => _mapper.Map<CarClassDto>(car)).ToList();
        }
        /// <summary>
        /// </summary>
        /// <remarks>
        /// Following Types are allowed
        /// Classic,
        /// Basic,
        /// Medium,
        /// Luxury
        /// </remarks>
        /// <param name="entity"></param>
        [HttpPost]
        public void Post([FromBody] CarClassDto entity)
        {
            var c = _mapper.Map<CarClass>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarClassDto entity)
        {
            var c = _mapper.Map<CarClass>(entity);
            _service.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
