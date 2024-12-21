using System;

namespace chuongtrinhquanlygarage.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }  // Changed 'CreateAt' to 'CreatedAt'
        public string Status { get; set; }
        public string Note { get; set; }
        public int Total { get; set; }
        public string EmployeeID { get; set; }  // Added getter and setter
        public string LicensePlate { get; set; }        // Added getter and setter

        // Constructor with parameters
        public Order(string orderId, DateTime createdAt, string status, string note, int total, string employeeID, string licensePlate)
        {
            OrderId = orderId;
            CreatedAt = createdAt;
            Status = status;
            Note = note;
            Total = total;
            EmployeeID = employeeID;
            LicensePlate = licensePlate;
        }

        // Parameterless constructor (needed for deserialization or ORM frameworks like Entity Framework)
        public Order() { }
    }
}
