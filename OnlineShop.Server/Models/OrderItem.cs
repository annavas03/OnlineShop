using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Server.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Кількість товару повинна бути більшою за 0.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Ціна повинна бути більшою за 0.")]
        public decimal Price { get; set; }
    }
}
