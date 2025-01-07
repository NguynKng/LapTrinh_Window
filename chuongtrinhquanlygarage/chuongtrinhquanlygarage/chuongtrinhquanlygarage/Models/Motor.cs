using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Models
{
    public class Motor {
        public string LicensePlate { get; set; }
        public Customer Customer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Motor(Customer customer, string licensePlate, string model, int year)
        {
            Customer = customer;
            LicensePlate = licensePlate;
            Model = model;
            Year = year;
        }

        public Motor() { }
    }
}
