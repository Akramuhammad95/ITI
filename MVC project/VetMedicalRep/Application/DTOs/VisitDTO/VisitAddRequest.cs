using Domain.Entities;

namespace Application.DTOs.VisitDTO
{
    public class VisitAddRequest
    {
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Notes { get; set; }

        public Visit ToVisit()
        {
            return new Visit(ClientId, UserId, VisitDate, Notes);
        }
    }
}
