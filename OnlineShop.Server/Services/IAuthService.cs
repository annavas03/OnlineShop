using OnlineShop.Server.DTOs;

namespace OnlineShop.Server.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
