using OnlineShop.Server.DTOs;
using OnlineShop.Server.DTOs.OnlineShop.Server.DTOs;
using System.Threading.Tasks;

namespace OnlineShop.Server.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(int userId);
        Task<bool> AddToCartAsync(int userId, CartItemDto cartItemDto); // Використовуємо один метод для додавання
        Task<bool> RemoveFromCartAsync(int cartItemId);
    }
}
