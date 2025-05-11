using OnlineShop.Data;
using OnlineShop.Server.DTOs;
using OnlineShop.Server.Models;
using OnlineShop.Server.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> CancelOrderAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateOrderAsync(CreateOrderDto orderDto)
    {
        var user = await _context.Users.FindAsync(orderDto.UserId);
        if (user == null)
        {
            throw new Exception($"User with ID {orderDto.UserId} not found.");
        }

        var order = new Order
        {
            UserId = orderDto.UserId,
            ShippingAddress = orderDto.ShippingAddress,
            CreatedAt = DateTime.UtcNow
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        foreach (var productId in orderDto.ProductIds)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) continue;

            _context.OrderItems.Add(new OrderItem
            {
                OrderId = order.Id,
                ProductId = productId,
                Quantity = 1 
            });
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public Task<OrderDto?> GetOrderByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderDto>> GetOrdersByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PlaceOrderAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
