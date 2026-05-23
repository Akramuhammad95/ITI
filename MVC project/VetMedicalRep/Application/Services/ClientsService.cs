using System;
using System.Threading.Tasks;
using Application.DTOs.ClientDTO;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ClientsService : IClientService
    {
        private readonly IUnitOfWork _uow;

        public ClientsService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }

        public async Task<ClientResponse> AddClientAsync(ClientAddRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var client = new Client(request.Name, request.Address);
            var added = await _uow.ClientRepository.AddAsync(client);
            await _uow.SaveChangesAsync();
            return added.ToClientResponse();
        }
    }
}
