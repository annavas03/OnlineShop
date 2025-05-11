namespace OnlineShop.Server.DTOs
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public List<int> ProductIds { get; set; } = new();
    }
}
