using OnlineShop.Server.DTOs;

namespace OnlineShop.Server.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<ProductDto> CreateProductAsync(ProductDto dto);
        Task<ProductDto> UpdateProductAsync(int id, ProductDto dto);
        Task<bool> DeleteProductAsync(int id);
    }
}
