using Domain.Entities;

namespace Application.DTOs.ProductDTO
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }
        public Guid CategoryId { get; set; }
    }

    public static class ProductExtensions
    {
        public static ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Discription = product.Discription,
                CategoryId = product.CategoryId
            };
        }
    }
}
