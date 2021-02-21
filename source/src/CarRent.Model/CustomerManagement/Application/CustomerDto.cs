using System;

namespace CarRent.Model.CustomerManagement.Application
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Street { get; set; }

        public Guid ZipId { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Place { get; set; }
    }
}
