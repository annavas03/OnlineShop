using AutoMapper;
using OnlineShop.Server.DTOs.OnlineShop.Server.DTOs;
using OnlineShop.Server.DTOs;
using OnlineShop.Server.Models;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartItem, CartItemDto>().ReverseMap();

        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<CreateOrderDto, Order>();
    }
}
