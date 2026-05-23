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
        //IBaseRepository<Order> OrderRepository { get; }

        Task<int> SaveChangesAsync();
    }
}