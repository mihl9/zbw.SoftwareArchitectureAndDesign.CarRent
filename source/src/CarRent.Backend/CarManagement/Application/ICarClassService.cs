using System;
using System.Collections.Generic;
using CarRent.Model.CarManagement.Domain;

namespace CarRent.Backend.CarManagement.Application
{
    public interface ICarClassService
    {
        List<CarClass> GetAll();

        List<CarClass> GetById(Guid id);

        void Add(CarClass car);

        void DeleteById(Guid id);

        void Delete(CarClass car);

        void Update(CarClass car);

    }
}