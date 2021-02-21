using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Backend.Common.Interfaces;
using CarRent.Model.CustomerManagement.Domain;

namespace CarRent.Backend.CustomerManagement.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer, Guid> _repository;

        public CustomerService(IRepository<Customer, Guid> repository)
        {
            _repository = repository;
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Customer> GetById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Add(Customer entity)
        {
            _repository.Insert(entity);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public void Delete(Customer entity)
        {
            _repository.Remove(entity);
        }

        public void Update(Customer entity)
        {
            _repository.Update(entity);
        }
    }
}
