using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Client> ClientRepository { get; }
        IBaseRepository<Manager> ManagerRepository { get; }
        IBaseRepository<Area> AreaRepository { get; }
        IBaseRepository<Product> ProductRepository { get; }
        IBaseRepository<Inventory> InventoryRepository { get; }
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Visit> VisitRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
