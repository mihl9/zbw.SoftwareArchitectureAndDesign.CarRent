using System;

namespace CarRent.Model.CarManagement.Application
{
    public class CarDto
    {
        public Guid Id { get; set; }
        
        public Guid ClassId { get; set; }

        public string Brand { get; set; }
        
        public string Type { get; set; }

        public string Class { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
