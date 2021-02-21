using System;
using System.ComponentModel.DataAnnotations;
using CarRent.Model.Common.Interfaces;

namespace CarRent.Model.CarManagement.Domain
{
    public class Car : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        
        public CarClass Class { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
