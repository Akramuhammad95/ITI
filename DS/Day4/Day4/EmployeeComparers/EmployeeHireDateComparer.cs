using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Day4
{
    public class EmployeeHireDateComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            return x.HireDate.CompareTo(y.HireDate);
        }
      
    }

}