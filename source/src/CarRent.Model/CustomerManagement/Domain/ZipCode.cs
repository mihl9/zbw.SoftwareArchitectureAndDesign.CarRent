using System;
using System.ComponentModel.DataAnnotations;
using CarRent.Model.Common.Interfaces;

namespace CarRent.Model.CustomerManagement.Domain
{
    public class ZipCode : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Town { get; set; }
    }
}
