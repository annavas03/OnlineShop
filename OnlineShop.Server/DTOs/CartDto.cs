namespace OnlineShop.Server.DTOs
{
    namespace OnlineShop.Server.DTOs
    {
        public class CartDto
        {
            public int Id { get; set; } 
            public int UserId { get; set; } 
            public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
            public decimal TotalPrice { get; set; } 
            public DateTime DateCreated { get; set; } = DateTime.Now;
        }

        public class CartItemDto
        {
            public int ProductId { get; set; } 
            public required string ProductName { get; set; } 
            public decimal Price { get; set; } 
            public int Quantity { get; set; } 
            public decimal Subtotal { get; set; } // (Price * Quantity)
        }
    }
}
