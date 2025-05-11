using OnlineShop.Models;

namespace OnlineShop.Server.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }  
        public User User { get; set; } = null!;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;


        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; internal set; }
        public string ShippingAddress { get; internal set; }
    }

    public enum OrderStatus
    {
        Pending,   
        Paid,      
        Shipped,   
        Cancelled  
    }
}
