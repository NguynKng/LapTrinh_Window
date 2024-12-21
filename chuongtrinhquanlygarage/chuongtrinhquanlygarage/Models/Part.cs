using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chuongtrinhquanlygarage.Models
{
    public class Part
    {
        public string PartId { get; set; }
        public string PartName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int BuyPrice { get; set; }
        public int EmployeePrice { get; set; }
        public string Unit {  get; set; }
        public int LimitStock { get; set; }


        public Part() { }

        public Part(string partId, string partName, int quantity, int price, int buyPrice, int employeePrice, string unit, int limitStock)
        {
            PartId = partId;
            PartName = partName;
            Quantity = quantity;
            Price = price;
            BuyPrice = buyPrice;
            EmployeePrice = employeePrice;
            Unit = unit;
            LimitStock = limitStock;
        }
    }
}
