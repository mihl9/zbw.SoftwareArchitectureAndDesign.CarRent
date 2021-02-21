using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model.CustomerManagement.Domain;

namespace CarRent.Backend.CustomerManagement.Application
{
    public interface ICustomerService
    {
        List<Customer> GetAll();

        List<Customer> GetById(Guid id);

        void Add(Customer entity);

        void DeleteById(Guid id);

        void Delete(Customer entity);

        void Update(Customer entity);
    }
}
