using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRent.Backend.CustomerManagement.Application;
using CarRent.Backend.ReservationManagement.Application;
using CarRent.Model.ReservationManagement.Application;
using CarRent.Model.ReservationManagement.Domain;

namespace CarRent.Backend.ReservationManagement.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ReservationDto> Get()
        {
            return _service.GetAll().Select(entity => _mapper.Map<ReservationDto>(entity)).ToList();
        }

        [HttpGet("{id}")]
        public List<ReservationDto> Get(Guid id)
        {
            return _service.GetById(id).Select(entity => _mapper.Map<ReservationDto>(entity)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] ReservationDto entity)
        {
            var c = _mapper.Map<Reservation>(entity);
            _service.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ReservationDto entity)
        {
            var c = _mapper.Map<Reservation>(entity);
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
