using System;

namespace CarRent.Model.CustomerManagement.Application
{
    public class ZipCodeDto
    {
        public Guid Id { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }
    }
}
