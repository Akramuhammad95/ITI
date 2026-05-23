using Application.DTOs;
using Domain.Entities;

public interface IClientRepository
{
    Task<Client> AddClientAsync(Client client);

}