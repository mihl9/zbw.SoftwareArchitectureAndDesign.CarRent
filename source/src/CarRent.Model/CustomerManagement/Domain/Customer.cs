using System;
using System.ComponentModel.DataAnnotations;
using CarRent.Model.Common.Interfaces;

namespace CarRent.Model.CustomerManagement.Domain
{
    public class Customer : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public Guid ZipId { get; set; }

        public ZipCode Zip { get; set; }
    }
}
