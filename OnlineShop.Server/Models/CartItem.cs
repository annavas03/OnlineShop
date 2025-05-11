using OnlineShop.Models;

namespace OnlineShop.Server.Models
{
    public class CartItem
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public required User User { get; set; }

        public int ProductId { get; set; }

        public required Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
