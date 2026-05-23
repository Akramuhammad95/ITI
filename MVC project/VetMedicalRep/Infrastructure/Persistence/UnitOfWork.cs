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
        public IBaseRepository<Product> ProductRepository { get; }
        public IBaseRepository<Inventory> InventoryRepository { get; }
        public IBaseRepository<User> UserRepository { get; }
        public IBaseRepository<Visit> VisitRepository { get; }

        public UnitOfWork(VetMedicalRepDbContext context)
        {
            _context = context;
            ClientRepository = new BaseRepository<Client>(_context);
            ManagerRepository = new BaseRepository<Manager>(_context);
            AreaRepository = new BaseRepository<Area>(_context);
            ProductRepository = new BaseRepository<Product>(_context);
            InventoryRepository = new BaseRepository<Inventory>(_context);
            UserRepository = new BaseRepository<User>(_context);
            VisitRepository = new BaseRepository<Visit>(_context);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
