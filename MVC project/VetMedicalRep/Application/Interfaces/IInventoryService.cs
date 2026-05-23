using Application.DTOs.InventoryDTO;

namespace Application.Interfaces
{
    public interface IInventoryService
    {
        Task<InventoryResponse> AddInventoryAsync(InventoryAddRequest request);
    }
}
