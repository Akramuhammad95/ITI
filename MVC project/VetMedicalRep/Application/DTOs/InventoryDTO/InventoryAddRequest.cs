using Domain.Entities;

namespace Application.DTOs.InventoryDTO
{
    public class InventoryAddRequest
    {
        public Guid ProductId { get; set; }
        public Guid AreaId { get; set; }
        public int InitialQuantity { get; set; }
        public int LowStockThreshold { get; set; } = 5;

        public Inventory ToInventory()
        {
            return new Inventory(ProductId, AreaId, InitialQuantity, LowStockThreshold);
        }
    }
}
