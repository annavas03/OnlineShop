using OnlineShop.Server.DTOs;
using OnlineShop.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Data;
using OnlineShop.Server.DTOs.OnlineShop.Server.DTOs;

namespace OnlineShop.Server.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CartDto> GetCartAsync(int userId)
        {
            var cart = await _context.Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync();

            if (cart == null)
                return null;

            var cartDto = new CartDto
            {
                Id = cart.CartId,
                UserId = cart.UserId,
                Items = cart.Items.Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity,
                    Subtotal = ci.Quantity * ci.Product.Price
                }).ToList(),
                TotalPrice = cart.Items.Sum(ci => ci.Quantity * ci.Product.Price),
                DateCreated = cart.DateCreated
            };

            return cartDto;
        }

  
        public async Task<bool> AddToCartAsync(int userId, CartItemDto cartItemDto)
        {
            var cart = await _context.Carts
                .Where(c => c.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    DateCreated = DateTime.Now
                };
                _context.Carts.Add(cart);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString());
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == cartItemDto.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {cartItemDto.ProductId} not found.");
            }

            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.CartId && ci.ProductId == cartItemDto.ProductId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += cartItemDto.Quantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = cartItemDto.ProductId,
                    Product = product,  
                    Quantity = cartItemDto.Quantity,
                    UserId = userId,  
                    User = user,  
                    DateAdded = DateTime.Now
                };
                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromCartAsync(int cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);

            if (cartItem == null)
                return false;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
