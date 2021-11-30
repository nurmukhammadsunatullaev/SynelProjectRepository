using System;
namespace BusinessLevel.Models
{
    public class PersonDtoModel
    {
        public Guid Id { get; set; }
        public string PayrollNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Address_2 { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
    }
}
