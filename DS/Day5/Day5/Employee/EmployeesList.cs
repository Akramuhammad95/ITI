using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class EmployeesList : IEnumerable
    {
        List<Employee> employees = new List<Employee>();

        private static int count = 0;

        public static int Count => count;

        public List<Employee> ToList => employees;
        public void Add(Employee employee)
        {
            employees.Add(employee);
            count++;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach (var emp in employees)
            {
                yield return emp;
            }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.Name} - {emp.HireDate.ToShortDateString()}");
            }
            return sb.ToString();

        }
    }

}