using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Customer(string id, string name, string address, string phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Customer() { }
    }
}
