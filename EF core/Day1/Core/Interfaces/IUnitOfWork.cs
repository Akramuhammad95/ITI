using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        Task<int> CompleteAsync();
    }
}
