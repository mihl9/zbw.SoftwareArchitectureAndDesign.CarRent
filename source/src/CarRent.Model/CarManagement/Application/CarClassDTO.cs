using System;

namespace CarRent.Model.CarManagement.Application
{

    public class CarClassDto
    {
        public Guid Id { get; set; }

        
        public string Type { get; set; }
        
        public decimal PricePerDay { get; set; }
    }
}
