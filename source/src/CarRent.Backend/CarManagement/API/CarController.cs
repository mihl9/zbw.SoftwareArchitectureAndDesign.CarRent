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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarDto> Get()
        {
            return _carService.GetAll().Select(car => _mapper.Map<CarDto>(car)).ToList();
        }

        [HttpGet("{id}")]
        public List<CarDto> Get(Guid id)
        {
            return _carService.GetById(id).Select(car => _mapper.Map<CarDto>(car)).ToList();
        }

        [HttpGet("search/{searchTerm}")]
        public List<CarDto> Search(string searchTerm)
        {
            return _carService.GetAll()
                .Where(x => x.Brand.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) || x.Type.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => _mapper.Map<CarDto>(x)).ToList();
        }

        [HttpPost]
        public void Post([FromBody] CarDto car)
        {
            var c = _mapper.Map<Car>(car);
            _carService.Add(c);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarDto car)
        {
            var c = _mapper.Map<Car>(car);
            _carService.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _carService.DeleteById(id);
        }
    }
}
