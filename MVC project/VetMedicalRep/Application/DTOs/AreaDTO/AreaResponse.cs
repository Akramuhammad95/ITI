using Domain.Entities;

namespace Application.DTOs.AreaDTO
{
    public class AreaResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public static class AreaExtensions
    {
        public static AreaResponse ToAreaResponse(this Domain.Entities.Area area)
        {
            return new AreaResponse
            {
                Id = area.Id,
                Name = area.Name,
                Description = area.Description,
                IsActive = area.IsActive
            };
        }
    }
}
