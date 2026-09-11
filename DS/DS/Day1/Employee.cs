using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public  class Employee
    {
        int _id;
        int _age;
        decimal _salary;
        string _departmentName;
        public Employee(int ID , int Age , decimal Salary , string Department)
        {
            _id = ID;
            _age = Age;
            _salary = Salary;
            _departmentName = Department;
   
        }
        public override string ToString()
        {
            return $" ID = {_id} , Age = {_age} , Salary = {_salary} , Department = {_departmentName}";
        }
    }
    
}

