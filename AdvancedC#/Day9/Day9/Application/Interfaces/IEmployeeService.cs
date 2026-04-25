using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Entities;


namespace Application.interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDto dto);
        Task<List<EmployeeDto>> SearchEmployee(string name);
    }
}
