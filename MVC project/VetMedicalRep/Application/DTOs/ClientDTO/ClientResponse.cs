using Domain.Entities;

namespace Application.DTOs.ClientDTO
{
    public class ClientResponse
    {

        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string Address { get;  set; }

    }

    public static class ClientExtensions
    {
        public static ClientResponse ToClientResponse(this Client client)
        {
            return new ClientResponse
            {
                Id = client.Id,
                Name = client.Name,
                Address = client.Address
            };
        }
    }
}
