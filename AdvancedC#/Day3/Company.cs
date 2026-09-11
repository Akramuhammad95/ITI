using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    public class Company 
    {
        private decimal _capital;

        public string Name { get; }
        public string Description { get; }


        public Company(string Name, string Description, decimal Capital)
        {
            this.Name = Name;
            this.Description = Description;
            this._capital = Capital;
        }
 class CompanyEmployees       
{
        public event Action<IEmployeeList> OnSalaryPaid;
        public event Action<IEmployeeList> OnSalaryUpdate;

        public delegate void SalaryPaidEventHandler(Employee e);


        //public delegate void SalaryPaEventHandler(object sender, SalaryPaidEventArgs salaryPaidEventArgs);
        public void PaySalaries(EmployeeList employees)
        {
            decimal totalSalaries = 0;



            if (!checkCapital(employees, ref totalSalaries))
            {
                throw new InvalidOperationException("Not enough capital to pay salaries.");
            }
            OnSalaryPaid?.Invoke(employees);



            _capital -= totalSalaries;
            
        }

            bool checkCapital(IEmployeeList employees, ref decimal totalSalaries)
            {
                foreach (var employee in employees)
                {
                    totalSalaries += employee.Salary;

                }
                return _capital >= totalSalaries;

            }
        

        public void UpdateSalaries(IEmployeeList employees, decimal percentageIncrease, Func<decimal, bool> checker)
        {
            decimal newSalary = 0;

            if (percentageIncrease < 0 || percentageIncrease > 100)
            {
                throw new ArgumentException("Percentage increase cannot be negative.");
            }

            foreach (var employee in employees)
            {
                if (!checker(employee.Salary))
                {
                    throw new InvalidOperationException($"Salary for {employee.Name} does not meet the criteria for an increase.");
                }
                newSalary = employee.Salary + (employee.Salary * percentageIncrease / 100);
                SetEmployeeSalary.setEmployeeSalary(employee, newSalary);
            }
            OnSalaryUpdate?.Invoke(employees);

        }
}{  public event Action<IEmployeeList> OnSalaryPaid;
        public event Action<IEmployeeList> OnSalaryUpdate;

        public delegate void SalaryPaidEventHandler(Employee e);


        //public delegate void SalaryPaEventHandler(object sender, SalaryPaidEventArgs salaryPaidEventArgs);
        public void PaySalaries(EmployeeList employees)
        {
            decimal totalSalaries = 0;



            if (!checkCapital(employees, ref totalSalaries))
            {
                throw new InvalidOperationException("Not enough capital to pay salaries.");
            }
            OnSalaryPaid?.Invoke(employees);



            _capital -= totalSalaries;
            
        }

            bool checkCapital(IEmployeeList employees, ref decimal totalSalaries)
            {
                foreach (var employee in employees)
                {
                    totalSalaries += employee.Salary;

                }
                return _capital >= totalSalaries;

            }
        

        public void UpdateSalaries(IEmployeeList employees, decimal percentageIncrease, Func<decimal, bool> checker)
        {
            decimal newSalary = 0;

            if (percentageIncrease < 0 || percentageIncrease > 100)
            {
                throw new ArgumentException("Percentage increase cannot be negative.");
            }

            foreach (var employee in employees)
            {
                if (!checker(employee.Salary))
                {
                    throw new InvalidOperationException($"Salary for {employee.Name} does not meet the criteria for an increase.");
                }
                newSalary = employee.Salary + (employee.Salary * percentageIncrease / 100);
                SetEmployeeSalary.setEmployeeSalary(employee, newSalary);
            }
            OnSalaryUpdate?.Invoke(employees);

        }
}  public event Action<IEmployeeList> OnSalaryPaid;
        public event Action<IEmployeeList> OnSalaryUpdate;

        public delegate void SalaryPaidEventHandler(Employee e);


        //public delegate void SalaryPaEventHandler(object sender, SalaryPaidEventArgs salaryPaidEventArgs);
        public void PaySalaries(EmployeeList employees)
        {
            decimal totalSalaries = 0;



            if (!checkCapital(employees, ref totalSalaries))
            {
                throw new InvalidOperationException("Not enough capital to pay salaries.");
            }
            OnSalaryPaid?.Invoke(employees);



            _capital -= totalSalaries;
            
        }

            bool checkCapital(IEmployeeList employees, ref decimal totalSalaries)
            {
                foreach (var employee in employees)
                {
                    totalSalaries += employee.Salary;

                }
                return _capital >= totalSalaries;

            }
        

        public void UpdateSalaries(IEmployeeList employees, decimal percentageIncrease, Func<decimal, bool> checker)
        {
            decimal newSalary = 0;

            if (percentageIncrease < 0 || percentageIncrease > 100)
            {
                throw new ArgumentException("Percentage increase cannot be negative.");
            }

            foreach (var employee in employees)
            {
                if (!checker(employee.Salary))
                {
                    throw new InvalidOperationException($"Salary for {employee.Name} does not meet the criteria for an increase.");
                }
                newSalary = employee.Salary + (employee.Salary * percentageIncrease / 100);
                SetEmployeeSalary.setEmployeeSalary(employee, newSalary);
            }
            OnSalaryUpdate?.Invoke(employees);

        }
>  public event Action<IEmployeeList> OnSalaryPaid;
        public event Action<IEmployeeList> OnSalaryUpdate;

        public delegate void SalaryPaidEventHandler(Employee e);


        //public delegate void SalaryPaEventHandler(object sender, SalaryPaidEventArgs salaryPaidEventArgs);
        public void PaySalaries(EmployeeList employees)
        {
            decimal totalSalaries = 0;



            if (!checkCapital(employees, ref totalSalaries))
            {
                throw new InvalidOperationException("Not enough capital to pay salaries.");
            }
            OnSalaryPaid?.Invoke(employees);



            _capital -= totalSalaries;
            
        }

            bool checkCapital(IEmployeeList employees, ref decimal totalSalaries)
            {
                foreach (var employee in employees)
                {
                    totalSalaries += employee.Salary;

                }
                return _capital >= totalSalaries;

            }
        

        public void UpdateSalaries(IEmployeeList employees, decimal percentageIncrease, Func<decimal, bool> checker)
        {
            decimal newSalary = 0;

            if (percentageIncrease < 0 || percentageIncrease > 100)
            {
                throw new ArgumentException("Percentage increase cannot be negative.");
            }

            foreach (var employee in employees)
            {
                if (!checker(employee.Salary))
                {
                    throw new InvalidOperationException($"Salary for {employee.Name} does not meet the criteria for an increase.");
                }
                newSalary = employee.Salary + (employee.Salary * percentageIncrease / 100);
                SetEmployeeSalary.setEmployeeSalary(employee, newSalary);
            }
            OnSalaryUpdate?.Invoke(employees);

        }
>
        
      
    }
   
}
