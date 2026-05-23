using Application.DTOs.ProductDTO;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> AddProductAsync(ProductAddRequest request);
    }
}
