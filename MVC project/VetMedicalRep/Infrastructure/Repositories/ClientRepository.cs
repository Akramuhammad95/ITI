using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : IBaseRepository<Client>
    {
        private readonly VetMedicalRepDbContext _context;

        public ClientRepository(VetMedicalRepDbContext context)
        {
            _context = context;
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            return entity;
        }

        public async Task<Client> DeleteAsync(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return null;
            _context.Clients.Remove(client);
            return client;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetAsync(Guid id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public Task<Client> UpdateAsync(Client entity)
        {
            _context.Clients.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
