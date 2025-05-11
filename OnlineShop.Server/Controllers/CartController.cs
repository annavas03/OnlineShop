using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Server.DTOs.OnlineShop.Server.DTOs;
using OnlineShop.Server.Services;
using System.Security.Claims;

namespace OnlineShop.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(userId, out int parsedUserId))
            {
                if (parsedUserId == 0)
                {
                    return Unauthorized(new { message = "Invalid user ID" });
                }

                var cart = await _cartService.GetCartAsync(parsedUserId);
                if (cart == null)
                {
                    return NotFound(new { message = "Cart not found" });
                }

                return Ok(cart);
            }

            return Unauthorized(new { message = "Invalid user ID format" });
        }


        [HttpPost]
        public async Task<ActionResult> AddToCart([FromBody] CartItemDto cartItemDto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized(new { message = "User not authenticated or invalid userId" });
            }

            var result = await _cartService.AddToCartAsync(userId, cartItemDto);

            if (result)
                return Ok(new { message = "Item added to cart" });

            return BadRequest(new { message = "Failed to add item to cart" });
        }

    }
}
