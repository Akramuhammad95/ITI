using Domain.Entities;

namespace Application.DTOs.VisitDTO
{
    public class VisitAddRequest
    {
        public Guid ClientId { get; set; }
        public Guid? UserId { get; set; }
        public IList<VisitProductDto>? Products { get; set; }
        public DateTime VisitDate { get; set; }
        public string Location { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public Visit ToVisit()
        {
            var visit = new Visit(ClientId, VisitDate, Location, UserId, Notes);
            if (Products != null)
            {
                foreach (var p in Products)
                {
                    visit.AddProduct(p.ProductId, p.Quantity);
                }
            }

            return visit;
        }
    }
}
