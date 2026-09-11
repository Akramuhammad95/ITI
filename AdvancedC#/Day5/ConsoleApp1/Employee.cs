using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    public class Employee
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; private set; }

        public Employee(int id, string name, string department, decimal salary)
        {
            ID = id;
            Name = name;
            Department = department;
            Salary = salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Department, Salary);

        }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return ID == other.ID &&
                       Name == other.Name &&
                       Department == other.Department &&
                       Salary == other.Salary;
            }
            return false;
        }   

    }
}
