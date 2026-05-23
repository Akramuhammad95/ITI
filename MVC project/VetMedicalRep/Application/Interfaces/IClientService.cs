using Application.DTOs.ClientDTO;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<ClientResponse> AddClientAsync(ClientAddRequest request);
    }
}
