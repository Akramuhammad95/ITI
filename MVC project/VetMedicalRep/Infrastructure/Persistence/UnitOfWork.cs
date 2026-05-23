using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VetMedicalRepDbContext _context;
        public IBaseRepository<Client> ClientRepository { get; }
        public IBaseRepository<Manager> ManagerRepository { get; }
        public IBaseRepository<Area> AreaRepository { get; }

        public UnitOfWork(VetMedicalRepDbContext context)
        {
            _context = context;
            ClientRepository = new BaseRepository<Client>(_context);
            ManagerRepository = new BaseRepository<Manager>(_context);
            AreaRepository = new BaseRepository<Area>(_context);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
