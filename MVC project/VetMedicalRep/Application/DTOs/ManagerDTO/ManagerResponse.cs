using Domain.Entities;

namespace Application.DTOs.ManagerDTO
{
    public class ManagerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static class ManagerExtensions
    {
        public static ManagerResponse ToManagerResponse(this Domain.Entities.Manager manager)
        {
            return new ManagerResponse
            {
                Id = manager.Id,
                Name = manager.Name,
                Email = manager.Email
            };
        }
    }
}
