using OnlineShop.Models;

namespace OnlineShop.Server.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime DateCreated { get; internal set; }
    }
}
