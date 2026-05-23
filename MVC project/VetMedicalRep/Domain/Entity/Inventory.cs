

using System;

using System;

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
    private Inventory() { } // EF Core / serialization

    public Inventory(Guid productId, Guid areaId, int initialQuantity = 0, int lowStockThreshold = 5)
    {
        if (initialQuantity < 0) throw new ArgumentException("Initial quantity cannot be negative.", nameof(initialQuantity));
        if (lowStockThreshold < 0) throw new ArgumentException("Low stock threshold cannot be negative.", nameof(lowStockThreshold));

        ProductId = productId;
        AreaId = areaId;
        QuantityInStock = initialQuantity;
        LowStockThreshold = lowStockThreshold;
        LastRestockedAt = DateTime.UtcNow;
    }

    public Guid ProductId { get; private set; }
    public Product? Product { get; private set; }

    public Guid AreaId { get; private set; }

    public int QuantityInStock { get; private set; }
    public int LowStockThreshold { get; private set; }
    public DateTime LastRestockedAt { get; private set; }

    public void IncreaseStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Increase amount must be positive.", nameof(amount));
        QuantityInStock += amount;
        LastRestockedAt = DateTime.UtcNow;
    }

    public void DecreaseStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("Decrease amount must be positive.", nameof(amount));
        if (amount > QuantityInStock) throw new InvalidOperationException("Cannot deduct more than available stock.");
        QuantityInStock -= amount;
    }

    public void SetLowStockThreshold(int threshold)
    {
        if (threshold < 0) throw new ArgumentException("Threshold cannot be negative.", nameof(threshold));
        LowStockThreshold = threshold;
    }

    public bool IsLowStock() => QuantityInStock <= LowStockThreshold;
}
