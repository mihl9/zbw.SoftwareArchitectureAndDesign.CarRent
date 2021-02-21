using System;
using System.Collections.Generic;
using CarRent.Model.CarManagement.Domain;

namespace CarRent.Backend.CarManagement.Application
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetById(Guid id);

        List<Car> GetByType(CarClassType type);

        void Add(Car car);

        void DeleteById(Guid id);

        void Delete(Car car);

        void Update(Car car);

    }
}