using OnlineShop.Server.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Server.Services
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(CreateOrderDto orderDto);
        Task<List<OrderDto>> GetOrdersByUserAsync(int userId);
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
        Task<bool> PlaceOrderAsync(int userId);
        Task<bool> CancelOrderAsync(int orderId);
    }
}
