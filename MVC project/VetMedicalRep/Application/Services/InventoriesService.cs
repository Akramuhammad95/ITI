using Application.DTOs.InventoryDTO;
using Application.Interfaces;

namespace Application.Services
{
    public class InventoriesService : IInventoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InventoryResponse> AddInventoryAsync(InventoryAddRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var inventory = request.ToInventory();
            var savedInventory = await _unitOfWork.InventoryRepository.AddAsync(inventory);
            await _unitOfWork.SaveChangesAsync();

            return savedInventory.ToInventoryResponse();
        }
    }
}
