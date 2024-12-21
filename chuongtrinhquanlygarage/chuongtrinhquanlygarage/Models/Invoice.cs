using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Models
{
    public class Invoice
    {
        public string Id { get; set; }
        public string OrderID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Total { get; set; }
        public string Method { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }

        public Invoice() { }

        public Invoice(string id, string orderID, DateTime checkIn, DateTime checkOut, int total,string method, string customerName, string employeeName)
        {
            Id = id;
            OrderID = orderID;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Total = total;
            Method = method;
            CustomerName = customerName;
            EmployeeName = employeeName;
        }
    }
}
