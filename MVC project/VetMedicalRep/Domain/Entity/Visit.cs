using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Visit
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Client? Client { get; private set; }

        public Guid? UserId { get; private set; }
        public User? User { get; private set; }

        public DateTime VisitDate { get; private set; }
        public string Location { get; private set; } = string.Empty;
        // many-to-many: Visit can have multiple products with quantities
        public ICollection<VisitProduct> VisitProducts { get; private set; } = new List<VisitProduct>();
        public string? Notes { get; private set; }
        public bool Completed { get; private set; }

        private Visit() { }

        public Visit(Guid clientId, DateTime visitDate, string location, Guid? userId = null, string? notes = null)
        {
            if (string.IsNullOrWhiteSpace(location)) throw new ArgumentException("Location is required.", nameof(location));
            ClientId = clientId;
            UserId = userId;
            VisitDate = visitDate;
            Location = location.Trim();
            VisitProducts = new List<VisitProduct>();
            Notes = notes?.Trim();
            Completed = false;
        }

        public void MarkCompleted()
        {
            Completed = true;
        }

        public void UpdateNotes(string? notes)
        {
            Notes = notes?.Trim();
        }

        public void AddProduct(Guid productId, int quantity = 0)
        {
            var vp = new VisitProduct(this, productId, quantity);
            VisitProducts.Add(vp);
        }

        public void RemoveProduct(Guid productId)
        {
            var existing = VisitProducts.FirstOrDefault(vp => vp.ProductId == productId);
            if (existing != null) VisitProducts.Remove(existing);
        }
    }
}
