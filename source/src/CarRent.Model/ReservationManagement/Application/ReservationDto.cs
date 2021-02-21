using System;

namespace CarRent.Model.ReservationManagement.Application
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int TotalDays { get; set; }

        public string Status { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public Guid CarId { get; set; }

        public string CarName { get; set; }

        public decimal TotalCost { get; set; }
    }
}
