using Domain.Entities;

namespace Application.DTOs.VisitDTO
{
    public class VisitResponse
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid UserId { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Notes { get; set; }
        public bool Completed { get; set; }
    }

    public static class VisitExtensions
    {
        public static VisitResponse ToVisitResponse(this Visit visit)
        {
            return new VisitResponse
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                UserId = visit.UserId,
                VisitDate = visit.VisitDate,
                Notes = visit.Notes,
                Completed = visit.Completed
            };
        }
    }
}
