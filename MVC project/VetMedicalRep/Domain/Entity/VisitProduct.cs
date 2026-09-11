using System;

namespace Domain.Entities
{
    public class VisitProduct
    {
        public Guid VisitId { get; private set; }
        public Visit Visit { get; private set; } = null!;

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int Quantity { get; private set; }

        private VisitProduct() { }

        // used when creating relationship after Visit instance exists
        internal VisitProduct(Visit visit, Guid productId, int quantity = 0)
        {
            if (visit is null) throw new ArgumentNullException(nameof(visit));
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));

            Visit = visit;
            VisitId = visit.Id;
            ProductId = productId;
            Quantity = quantity;
        }

        // fallback ctor when only product id is known (EF can populate Visit/VisitId later)
        public VisitProduct(Guid productId, int quantity = 0)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            ProductId = productId;
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.", nameof(quantity));
            Quantity = quantity;
        }
    }
}
