using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model.ReservationManagement.Domain;

namespace CarRent.Backend.ReservationManagement.Application
{
    public interface IReservationService
    {
        List<Reservation> GetAll();

        List<Reservation> GetById(Guid id);

        void Add(Reservation entity);

        void DeleteById(Guid id);

        void Delete(Reservation entity);

        void Update(Reservation entity);
    }
}
