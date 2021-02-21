using System;
using System.ComponentModel.DataAnnotations;
using CarRent.Model.Common.Interfaces;

namespace CarRent.Model.CarManagement.Domain
{
    public enum CarClassType
    {
        Classic,
        Basic,
        Medium,
        Luxury
    }
    public class CarClass : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public CarClassType Type { get; set; }
        [Required]
        public decimal PricePerDay { get; set; }
    }
}
