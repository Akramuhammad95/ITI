using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.DTOs.VisitDTO
{
    public class VisitResponse
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid? UserId { get; set; }
        public IList<VisitProductDto>? Products { get; set; }
        public DateTime VisitDate { get; set; }
        public string Location { get; set; } = string.Empty;

        public string? Notes { get; set; }
        public bool Completed { get; set; }
    }

    public static class VisitExtensions
    {
        public static VisitResponse ToVisitResponse(this Visit visit)
        {
            var resp = new VisitResponse
            {
                Id = visit.Id,
                ClientId = visit.ClientId,
                UserId = visit.UserId,
                VisitDate = visit.VisitDate,
                Location = visit.Location,
                Notes = visit.Notes,
                Completed = visit.Completed,
                Products = visit.VisitProducts?.Select(vp => new VisitProductDto { ProductId = vp.ProductId, Quantity = vp.Quantity }).ToList()
            };

            return resp;
        }
    }
}
