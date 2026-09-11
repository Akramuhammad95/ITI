using Application.DTOs.AreaDTO;
using Application.DTOs.ClientDTO;
using Application.DTOs.InventoryDTO;
using Application.DTOs.ProductDTO;
using Application.DTOs.VisitDTO;

namespace Presentation.ViewModels
{
    public class DashboardViewModel
    {
        public ClientAddRequest NewClient { get; set; } = new();
        public VisitAddRequest NewVisit { get; set; } = new() { VisitDate = DateTime.Now };
        public AreaAddRequest NewArea { get; set; } = new();
        public ProductAddRequest NewProduct { get; set; } = new();
        public InventoryAddRequest NewInventory { get; set; } = new() { LowStockThreshold = 5 };

        public IReadOnlyList<ClientResponse> Clients { get; set; } = [];
        public IReadOnlyList<VisitResponse> Visits { get; set; } = [];
        public IReadOnlyList<AreaResponse> Areas { get; set; } = [];
        public IReadOnlyList<ProductResponse> Products { get; set; } = [];
        public IReadOnlyList<InventoryResponse> Inventories { get; set; } = [];
    }
}
