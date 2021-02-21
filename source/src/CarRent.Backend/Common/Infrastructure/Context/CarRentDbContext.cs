using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.CustomerManagement.Domain;
using CarRent.Model.ReservationManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Backend.Common.Infrastructure.Context
{
    public class CarRentDbContext : BaseDbContext
    {
        public CarRentDbContext(DbContextOptions options) : base(options) { }

        //Add the Main Data Models
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ZipCode> ZipCodes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureModelBinding<Car, Guid>(modelBuilder);
            ConfigureModelBinding<CarClass, Guid>(modelBuilder);
            ConfigureModelBinding<Customer, Guid>(modelBuilder);
            ConfigureModelBinding<ZipCode, Guid>(modelBuilder);
            ConfigureModelBinding<Reservation, Guid>(modelBuilder);
        }
    }
}
