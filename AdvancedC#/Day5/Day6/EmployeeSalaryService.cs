using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    public class EmployeeSalaryService
    {
        [Obsolete("This method is obslete",false)]
        public void UpdateSalary(Employee employee, double Amount)
        {
            decimal salary = employee.Salary;

            decimal NewSalary = salary* (decimal)Amount + salary;
            employee.setSalary(NewSalary);
        }

        [StereoType("Service", "Handles product discounts")]
        public class DiscountService
        {
            public void ApplyDiscount(Employee employee)
            {
                Console.WriteLine($"Discount applied to {employee.Name} with {employee.Salary*(decimal)0.25}");
            }
        }
    }
}
