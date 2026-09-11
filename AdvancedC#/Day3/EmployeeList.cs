using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Day3
{
    public class EmployeeList : IEmployeeList , IEnumerable<Employee>
    {
        private List<Employee> _employees = new List<Employee>();

        public Employee this[int i] => _employees[i];
     
        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public IEnumerator<Employee> GetEnumerator()
        {  return _employees.GetEnumerator(); }

        public List<Employee> GetEmployees=> _employees;


        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
        
    }
 
}
