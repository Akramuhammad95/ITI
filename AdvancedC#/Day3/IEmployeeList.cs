using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public interface IEmployeeList : IEnumerable<Employee>
    {
        void AddEmployee(Employee employee);
        void RemoveEmployee(Employee employee);

    }
}
