using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRent.Model.CarManagement.Domain;
using CarRent.Model.Common.Interfaces;
using CarRent.Model.CustomerManagement.Domain;

namespace CarRent.Model.ReservationManagement.Domain
{
    public enum ReservationStatus {
        Reserved,
        Rent
    }

    public class Reservation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }

        [NotMapped]
        public int TotalDays
        {
            get
            {
                if (Start < End)
                {
                    var result = End - Start;
                    return result.Days;
                }
                else
                {
                    return 0;
                }
            }
        }

        public ReservationStatus Status { get; set; }
        [Required]
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }
        [Required]
        public Guid CarId { get; set; }

        public Car Car { get; set; }
    }
}
