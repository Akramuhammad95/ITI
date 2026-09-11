

namespace Domain.Entities;

/// <summary>
/// Tracks stock levels for a Product in a specific area/warehouse.
/// 
/// Business Rules:
/// - Stock quantity can NEVER go below zero
/// - Cannot deduct more than what's available
/// - Low-stock warning threshold triggers an alert signal
/// - Quantity adjustments are always explicit (no direct setters)
/// </summary>
public class Inventory 
{
    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }

    public Guid AreaId { get; private set; }

    public int QuantityInStock { get; private set; }
    public int LowStockThreshold { get; private set; }
    public DateTime LastRestockedAt { get; private set; }

    private Inventory() { } // EF Core / serialization


}
