using Application.DTOs.ProductDTO;
using Application.Interfaces;

namespace Application.Services
{
    public class ProductsService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> AddProductAsync(ProductAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Product name is required.");

            var product = request.ToProduct();
            var savedProduct = await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return savedProduct.ToProductResponse();
        }
    }
}
