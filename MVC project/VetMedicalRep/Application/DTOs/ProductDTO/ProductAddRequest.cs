using Domain.Entities;

namespace Application.DTOs.ProductDTO
{
    public class ProductAddRequest
    {
        public string Name { get; set; }
        public string? Discription { get; set; }
        public Guid CategoryId { get; set; }

        public Product ToProduct()
        {
            return new Product(Name, Discription, CategoryId);
        }
    }
}
