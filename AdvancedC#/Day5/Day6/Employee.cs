using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
[assembly:CLSCompliantAttribute(true)]
namespace Day6
{
    [Serializable]
    public class Employee
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }
        public decimal Salary { get; private set; }
        public Employee(decimal salary)
        {
            Salary = salary;
             
        }

        internal  decimal  setSalary(decimal salary) => Salary = salary;


    }
}
