using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class EmployeesList<Employee> : IEnumerable<Employee>
    {
        List<Employee> employees = new List<Employee>();

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            foreach(var emp in employees)
            {
               yield return emp;
            }
            

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
