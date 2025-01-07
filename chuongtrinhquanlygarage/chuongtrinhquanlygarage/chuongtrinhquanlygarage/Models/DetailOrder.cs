namespace chuongtrinhquanlygarage.Models
{
    public class DetailOrder
    {
        public int Quantity { get; set; }       // Capitalized 'Quantity' following C# convention
        public string OrderId { get; set; }     // Foreign key for Order (string, matching your Order ID type)
        public string PartId { get; set; }      // Foreign key for Part (string, matching your Part ID type)
        public int Price { get; set; }

        // Constructor with parameters
        public DetailOrder(int quantity, string orderId, string partId, int price)
        {
            Quantity = quantity;
            OrderId = orderId;
            PartId = partId;
            Price = price;
        }

        // Parameterless constructor (needed for deserialization or ORM frameworks like Entity Framework)
        public DetailOrder() { }
    }
}
