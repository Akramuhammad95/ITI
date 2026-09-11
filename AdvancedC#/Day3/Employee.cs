using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public class Employee
    {
        private decimal _salary; 
        private static int _lastID = 0;
        public string Name { get;  }
        public int Id { get; }
        public decimal Salary => _salary;
        public Employee(string Name , decimal Salary)
        {
            Id+= _lastID++;
            this.Name = Name;
            this._salary = Salary;
        }

        public override string ToString()
        {
            return $"Employee ID: {Id}, Name: {Name}, Salary: {Salary:C}";
        }

        internal void SetEmployeeSalary(Employee employee, decimal newSalary)
        {
            this._salary= newSalary;
        }

    }
}
