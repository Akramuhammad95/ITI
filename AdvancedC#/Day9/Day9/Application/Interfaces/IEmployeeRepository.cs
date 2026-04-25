using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
         Task<List<Employee>> Search(string name);
    }
}
