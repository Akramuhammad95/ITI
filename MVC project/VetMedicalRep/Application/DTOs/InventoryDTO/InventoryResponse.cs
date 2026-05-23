using Domain.Entities;

namespace Application.DTOs.InventoryDTO
{
    public class InventoryResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid AreaId { get; set; }
        public int QuantityInStock { get; set; }
        public int LowStockThreshold { get; set; }
        public DateTime LastRestockedAt { get; set; }
        public bool IsLowStock { get; set; }
    }

    public static class InventoryExtensions
    {
        public static InventoryResponse ToInventoryResponse(this Inventory inventory)
        {
            return new InventoryResponse
            {
                Id = inventory.Id,
                ProductId = inventory.ProductId,
                AreaId = inventory.AreaId,
                QuantityInStock = inventory.QuantityInStock,
                LowStockThreshold = inventory.LowStockThreshold,
                LastRestockedAt = inventory.LastRestockedAt,
                IsLowStock = inventory.IsLowStock()
            };
        }
    }
}
